using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Canvas pauseCanvas;
    public Canvas gameCanvas;
    public Canvas settingsCanvas;
    public Canvas endCanvas;

    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI finalScoreText;

    private void Awake(){
        instance = this;
    }

    public void ShowPauseCanvas(){
        HideAllCanvases();
        pauseCanvas.gameObject.SetActive(true);
    }

    public void ShowGameCanvas(){
        HideAllCanvases();
        gameCanvas.gameObject.SetActive(true);
    }

    public void ShowSettingsCanvas(){
        HideAllCanvases();
        settingsCanvas.gameObject.SetActive(true);
    }

    public void ShowEndCanvas(){
        HideAllCanvases();
        endCanvas.gameObject.SetActive(true);
    }
    
    private void HideAllCanvases(){
        pauseCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(false);
    }

    public void UpdateScoreText(int newScore){
        scoreText.text = "Score: " + newScore;
        finalScoreText.text = "Final Score: " + newScore;
    }

    
}
