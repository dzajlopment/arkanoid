using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    float ballPositionY;
    public GameObject ball;
    public Transform platform;
    float platformPositionX;
    Vector2 ballOnPlatformPosition;


    // Update is called once per frame
    void Update() {
        ballPositionY = transform.position.y;
        
        if(ballPositionY < -6){
            LifesSystem.instance.removeLife();
            platformPositionX = platform.transform.position.x;
            // print(platformPositionX);

            BallVelocity.instance.Catch(platform);
            ballOnPlatformPosition = new Vector2(platformPositionX, (float)-3.88);
            print(platformPositionX);
            transform.position = ballOnPlatformPosition;
            // ball.transform.SetParent(platform);
            //y=0.249
        }
    }
}
