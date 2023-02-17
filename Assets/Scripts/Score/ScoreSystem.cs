using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour {
    public static ScoreSystem instance;
    public TextMeshProUGUI scoreText;
    int score = 0;

    void refreshScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        refreshScoreText();
    }

    public void AddPoints(int points){
        score+=points;
        refreshScoreText();
    }
}
