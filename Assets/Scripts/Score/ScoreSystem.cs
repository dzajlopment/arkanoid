using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour {
    public static ScoreSystem instance;
    public TextMeshProUGUI scoreText;
    int score = 0;
    int counter = 1;

    bool reached20k = false;
    bool reached60k = false;


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

        if(score>=20000 && reached20k == false){
            LifesSystem.instance.addLife();
            reached20k = true;
        }

        if(score >= 60000 && reached60k == false){
            LifesSystem.instance.addLife();
            reached60k = true;
        }

        if(score/60000 > counter){
            LifesSystem.instance.addLife();
            counter = score/60000;
        }

        refreshScoreText();
        if(score >= 1000 && Powerups.areEnoughPoints == false){
            Powerups.areEnoughPoints = true;
        }
    }
}
