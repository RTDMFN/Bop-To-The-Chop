using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    void Update(){
        if(GameManager.instance.state == GameState.Playing){
            if(Input.GetKeyDown(KeyCode.Space)){
                Conductor.instance.HitDown();
            }

            if(Input.GetKeyUp(KeyCode.Space)){
                Conductor.instance.HitUp();
            }
        }        
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            GameManager.instance.Pause();
        }
    }
}
