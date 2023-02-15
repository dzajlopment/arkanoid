using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle toggle;

    void Start()
    {
        toggle.isOn = Screen.fullScreen;
    }

    public void PlayGame()
    {
        Debug.LogError("Not implemented");
    }
    
    public void RunEditor()
    {
        SceneManager.LoadScene("Editor");
    }
    
    public void ShowHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = toggle.isOn;
    }
}
