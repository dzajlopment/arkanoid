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

    public Sprite [] sprites = {};

    int PowerUp;

    // Start is called before the first frame update
    void Start()
    {
        Powerups.shouldPowerupSpawn = false;
        //PowerUp = 7; //testing purposes
        PowerUp = Random.Range(1, 8); //randomise which powerup is dropped
        switch (PowerUp)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = sprites[3];
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = sprites[4];
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = sprites[5];
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = sprites[6];
                break;
            case 7:
                GetComponent<SpriteRenderer>().sprite = sprites[7];
                break;
        }
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

    public void resetPowerups()
    {
        Powerups.instance.interruptGuard();
        Powerups.instance.shortPlatform();
        Powerups.instance.laserDisabled();
        Powerups.instance.isBallPowerful = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            
            Powerups.instance.refreshCapsule();
            switch (PowerUp)
            {
                case 0:
                    TriggerThreeBalls();
                    break;
                case 1:
                    LifesSystem.instance.addLife();
                    break;
                case 2:
                    resetPowerups();
                    Powerups.instance.longPlatform();
                    break;
                case 3:
                    resetPowerups();
                    Powerups.instance.laserEnabled();
                    break;
                case 4:
                    resetPowerups();



                    break;
                case 5:
                    resetPowerups();
                    Powerups.instance.isBallPowerful = true;
                    break;
                case 6:
                    resetPowerups();
                    Powerups.instance.enableGuard();
                    break;
                case 7:
                    Powerups.instance.createExits();
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
