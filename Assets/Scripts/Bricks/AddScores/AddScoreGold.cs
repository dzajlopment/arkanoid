using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreGold : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        ScoreSystem.instance.AddPoints(120);
    }
}
