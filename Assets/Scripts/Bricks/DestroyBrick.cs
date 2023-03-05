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
        trueSilverHp = GameManager.Instance.Level / 8;
    }

    void removeLife(){
        trueSilverHp--;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(gameObject.name.StartsWith("truewhite--brick")){
        //remove one hp from truewhite--brick
            removeLife();
            if(trueSilverHp == 0){
                GameManager.Instance.AddPoints(50 * GameManager.Instance.Level);
                Sound.instance.playDestroyedBrickSound();
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
            Sound.instance.playDestroyedBrickSound();
            Destroy(gameObject);
        }
        OnBrickDestroyed.Invoke(Colour);
    }
}