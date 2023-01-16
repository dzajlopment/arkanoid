using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
