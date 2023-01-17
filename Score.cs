using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    private  int score;

    private void Awake(){
        instance = this;
    }

    public void IncrementScore(int multiplier){
        score += 100 * multiplier;
        MenuManager.instance.UpdateScoreText(score);
    }
}
