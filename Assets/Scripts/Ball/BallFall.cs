using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    float ballPositionY;
    // Update is called once per frame
    void Update() {
        ballPositionY = transform.position.y;
        print(ballPositionY);
        
        if(ballPositionY < -6){
            LifesSystem.instance.removeLife();
        }
    }
}
