using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    float ballPositionY;
    public GameObject ball;
    public GameObject platformObject;
    public Transform platform;
    float platformPositionX;
    Vector2 ballOnPlatformPosition;
    int lifes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Length <= 5)
        {
            return;
        }
        if (Powerups.instance.isBallPowerful && collision.name.Substring(0, 6) == "brick-")
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        ballPositionY = transform.position.y;
        
        if(ballPositionY < -6){
            GameManager.Instance.RemoveLife();
            lifes = GameManager.Instance.Lifes;
            Powerups.instance.resetPowerups();
            Powerups.instance.refreshCapsule();
            //Delete the ball and platform on 0 lifes
            if (lifes == 0){
                Destroy(ball);
                Destroy(platformObject);
                return;
            }

            //Move the ball on platform
            platformPositionX = platform.transform.position.x;
            BallVelocity.instance.Catch(platform);
            ballOnPlatformPosition = new Vector2(platformPositionX, (float)-3.88);
            transform.position = ballOnPlatformPosition;
        }
    }
}
