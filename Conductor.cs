using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public static Conductor instance;

    public float songBPM;
    public float secondsPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float deltaSongPosition;
    public float songStartOffset;
    public float timeOfLastBeat;
    public float dspSongTime;
    public float inputThreshold;
    public AudioSource musicSource;

    public float goodThreshold;
    public float greatThreshold;
    public float perfectThreshold;
    public int goodMultiplier;
    public int greatMultiplier;
    public int perfectMultiplier;
    public Transform sweetSpot;

    Note targetNote;
    public GameObject expandingCircle;
    public Transform player;

    public AudioSource HitSound;
    public AudioSource ReadySound;

    public float pauseTimeStamp;

    public bool musicHasStarted = false;

    private void Awake(){
        instance = this;
        AudioListener.pause = false;
    }

    private void Start(){
        pauseTimeStamp = -1f;
        musicSource = GetComponent<AudioSource>();
        secondsPerBeat = 60/songBPM;
        dspSongTime = (float)AudioSettings.dspTime;
        timeOfLastBeat = 0;
    }

    private void Update(){
        if(!musicHasStarted) return;

        if(!musicSource.isPlaying && GameManager.instance.state != GameState.Paused && songPosition > musicSource.clip.length){
            GameManager.instance.EndGame();
        }

        if(GameManager.instance.state == GameState.Paused){
            if(pauseTimeStamp < 0f){
                pauseTimeStamp = (float)AudioSettings.dspTime;
                AudioListener.pause = true;
                // musicSource.Pause();
            }
            return;
        }else if(pauseTimeStamp > 0f){
            AudioListener.pause = false;
            // musicSource.UnPause();
            pauseTimeStamp = -1f;
        }

        deltaSongPosition = ((float)(AudioSettings.dspTime - dspSongTime) * musicSource.pitch - songStartOffset) - songPosition;
        songPosition = (float)(AudioSettings.dspTime - dspSongTime) * musicSource.pitch - songStartOffset;
        songPositionInBeats = songPosition/secondsPerBeat;

        if(songPosition > timeOfLastBeat + secondsPerBeat){
            StartCoroutine(Flash());
            timeOfLastBeat += secondsPerBeat;
        }
    }

    IEnumerator Flash(){
        NoteSpawner.instance.SpawnEntity();
        yield return new WaitForSeconds(inputThreshold);
    }

    public void UpdateTargetNote(Note newTargetNote){
        // Debug.Log("Updating target note");
        targetNote = newTargetNote;
    }

    public void HitDown(){
        if(targetNote == null) return;
        
        if(targetNote.gap){
            //Hit
            Instantiate(expandingCircle,player.position,Quaternion.identity);
            ReadySound.Play();
            Debug.Log("Hit");
        }
        if(targetNote.note){
            //Miss
            Debug.Log("Miss");
            return;
        }
        CheckHitQuality();
    }

    public void HitUp(){
        if(targetNote == null) return;

        if(targetNote.gap){
            //Miss
            Debug.Log("Miss");
            return;
        }
        if(targetNote.note){
            //Hit
            targetNote.gameObject.GetComponent<Animator>().Play("Chop");
            HitSound.Play();
            Debug.Log("Hit");
        }
        CheckHitQuality();
    }

    void CheckHitQuality(){
        Vector2 notePosition = targetNote.gameObject.transform.position;
        Vector2 sweetSpotPosition = sweetSpot.position;
        float distanceFromSweetSpot = Mathf.Abs(notePosition.x - sweetSpotPosition.x);

        if(distanceFromSweetSpot <= perfectThreshold){
            //award 3x
            Score.instance.IncrementScore(perfectMultiplier);
            return;
        }
        else if(distanceFromSweetSpot <= greatThreshold){
            //award 2x
            Score.instance.IncrementScore(greatMultiplier);
            return;
        }
        else if(distanceFromSweetSpot <= goodThreshold){
            //award 1x
            Score.instance.IncrementScore(goodMultiplier);
            return;
        }
    }
}
