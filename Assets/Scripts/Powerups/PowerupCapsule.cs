using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class PowerupCapsule : MonoBehaviour
{
    
        //ExtraBalls 0
        //ExtraLife 1
        //ExtraLength 2
        //LaserMode 3
        //StickyPlatform 4
        //ExtraShot 5
        //GuardianAngel 6
        //FinishLevel 7
    

    int PowerUp;

    // Start is called before the first frame update
    void Start()
    {
        Powerups.shouldPowerupSpawn = false;
        PowerUp = 6;
        //PowerUp = Random.Range(1, 8); //randomise which powerup is dropped
        // change texture of capsule depending on powerup
    }

    void TriggerThreeBalls() // WIP
    {
        //Powerups.numBalls = 3;
        //GameObject platform1 = Instantiate(Powerups.instance.platform, FindObjectOfType<Platform>().transform);
        //BallVelocity ball = platform1.GetComponentInChildren<BallVelocity>();
        //ball.Launch(new Vector2(-0.5f, 1f));
        //GameObject platform2 = Instantiate(Powerups.instance.platform, FindObjectOfType<Platform>().transform);
        //ball = platform2.GetComponentInChildren<BallVelocity>();
        //ball.Launch(new Vector2(0.5f, 1f));
    }

    private void OnDestroy()
    {
        //Powerups.shouldPowerupSpawn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            Powerups.instance.interruptGuard();
            Powerups.instance.shortPlatform();
            Powerups.instance.laserDisabled();
            switch (PowerUp)
            {
                case 0:
                    TriggerThreeBalls();
                    break;
                case 1:
                    LifesSystem.instance.addLife();
                    break;
                case 2:
                    Powerups.instance.longPlatform();
                    break;
                case 3:
                    Powerups.instance.laserEnabled();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Powerups.instance.enableGuard();
                    break;
                case 7:
                    break;


            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
