using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float moveSpeed;

    public bool note;
    public bool gap;

    public bool readyToDie;

    void Update(){
        if(GameManager.instance.state == GameState.Playing) transform.Translate(Vector2.left * moveSpeed * Conductor.instance.deltaSongPosition);

        if(readyToDie){
            if(!this.GetComponentInChildren<SpriteRenderer>().isVisible) Destroy(this.gameObject,2);
        }
    }
}
