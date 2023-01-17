using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScores : MonoBehaviour
{
    public TextMeshProUGUI names;
    public TextMeshProUGUI scores;

    void Start()
    {
        var records = ScoreManager.GetScores().OrderByDescending(s => s.Score).Take(10);

        var i = 1;
        foreach (var record in records)
        {
            names.text += $"{i}. {record.Player}\n";
            scores.text += $"{record.Score}\n";
            i++;
        }
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ClearScores()
    {
        ScoreManager.ClearRecords();
    }
}
