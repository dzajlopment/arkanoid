using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyBrick : MonoBehaviour{
    public BrickColour Colour;
    public delegate void BrickDestroyed(BrickColour colour);
    public static event BrickDestroyed OnBrickDestroyed;

    int trueSilverHp = 1;

    void Awake() {
        //check
        if (GameManager.Instance == null)
        {
            Debug.Log("RUCHANIE");
        }
        trueSilverHp = GameManager.Instance.Level / 8;
        Debug.Log(trueSilverHp);
    }

    // public VideoPlayer videoPlayer;

    void removeLife(){
        trueSilverHp--;
    }

    public GameObject powerupCapsule; //for spawning of powerup capsules

    void OnCollisionEnter2D(Collision2D collision) {


        if(gameObject.name.StartsWith("truewhite--brick")){
        //remove one hp from truewhite--brick
            removeLife();
            if(trueSilverHp == 0){
                GameManager.Instance.AddPoints(50 * GameManager.Instance.Level);
                Sound.instance.playDestroyedBrickSound();
                GameManager.Instance.SilverBricks--;
                Destroy(gameObject);
            }
            else{
                Sound.instance.playBallBounceSound();
            }
        }

        //check if brick is truegold--brick
        else if(gameObject.name.StartsWith("truegold--brick")){
            Sound.instance.playGoldBlockHitSound();
        }

        //every colorful brick
        else {
            if (Powerups.shouldPowerupSpawn && Powerups.areEnoughPoints)
            {
                GameObject capsule = Instantiate(powerupCapsule, gameObject.transform);
                capsule.transform.parent = gameObject.transform.parent;
                capsule.transform.position = new Vector2(capsule.transform.position.x + 4.48f, transform.position.y);
            }

            Sound.instance.playDestroyedBrickSound();
            // videoPlayer.Play();
            // Destroy(gameObject, 0.3f);
            Destroy(gameObject);
        }
        OnBrickDestroyed.Invoke(Colour);
    }
}