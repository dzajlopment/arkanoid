using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ClearScores()
    {
        Debug.LogError("Not implemented");
    }
}
