using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    public Canvas settingsCanvas;
    // public Canvas tutorialCanvas;
    public Canvas mainMenuCanvas;

    private void Awake(){
        instance = this;
    }

    private void HideAllCanvases(){
        settingsCanvas.gameObject.SetActive(false);
        // tutorialCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(false);
    }

    public void ShowSettingsCanvas(){
        HideAllCanvases();
        settingsCanvas.gameObject.SetActive(true);
    }

    // public void ShowTutorialCanvas(){
    //     HideAllCanvases();
    //     tutorialCanvas.gameObject.SetActive(true);
    // }
    
    public void ShowMainMenuCanvas(){
        HideAllCanvases();
        mainMenuCanvas.gameObject.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }
}
