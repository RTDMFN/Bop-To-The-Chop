using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        // Debug.Log("Something hit");
        if(other.tag == "Gap" || other.tag == "Note"){
            // Debug.Log("Gap or note hit");
            Conductor.instance.UpdateTargetNote(other.GetComponent<Note>());
        }
    }

    void OnTriggerExit2D(Collider2D other){
        // Debug.Log("Something exiting");
        if(other.tag == "Gap" || other.tag == "Note"){
            // Debug.Log("Gap or Note is exiting");
            other.GetComponent<Note>().readyToDie = true;
        }
    }
}
