using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

    public float lerpDuration;
    public Transform startPosition;
    public Transform targetPosition;
    public Transform playerPosition;

    private void Awake(){
        instance = this;
    }

    private void Start(){
        if(SceneManager.GetActiveScene().name == "Test_Game") StartCoroutine(StartGame());
        if(SceneManager.GetActiveScene().name == "Game") StartCoroutine(StartGame());
        if(SceneManager.GetActiveScene().name == "Test_MainMenu") return;
    }

    private void SwitchState(GameState newState){
        switch(newState){
            case GameState.Playing:
                HandlePlayingState();
                break;
            case GameState.Paused:
                HandlePausedState();
                break;
            case GameState.End:
                HandleEndState();
                break;
            case GameState.Default:
                HandleDefaultState();
                break;
        }
    }

    private void HandlePlayingState(){
        state = GameState.Playing;
        Time.timeScale = 1;
        MenuManager.instance.ShowGameCanvas();
    }

    private void HandlePausedState(){
        state = GameState.Paused;
        Time.timeScale = 0;
        MenuManager.instance.ShowPauseCanvas();
    }

    private void HandleDefaultState(){
        state = GameState.Default;
        Debug.Log("WHY ARE WE IN DEFAULT");
    }

    private void HandleEndState(){
        state = GameState.End;
        MenuManager.instance.ShowEndCanvas();
    }

    public void Pause(){
        if(state == GameState.Paused) SwitchState(GameState.Playing);
        else if(state == GameState.Playing) SwitchState(GameState.Paused);
    }

    public void EndGame(){
        SwitchState(GameState.End);
    }

    IEnumerator StartGame(){
        float timeElapsed = 0;
        startPosition = playerPosition;
        while(timeElapsed < lerpDuration){
            playerPosition.position = Vector3.Lerp(startPosition.position,targetPosition.position,timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            if(Vector3.Distance(playerPosition.position,targetPosition.position) < 0.01f) break;
            yield return null;
        }
        playerPosition.position = targetPosition.position;

        SwitchState(GameState.Playing);
        Conductor.instance.musicHasStarted = true;
        Conductor.instance.musicSource.Play();
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu(){
        SwitchState(GameState.Playing);
        SceneManager.LoadScene("MainMenu");
    }

}

public enum GameState{
    Default,
    Paused,
    Playing,
    End
}
