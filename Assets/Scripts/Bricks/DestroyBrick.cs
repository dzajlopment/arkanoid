using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DestroyBrick : MonoBehaviour{
    int trueSilverHp = 2;  //2 + (level / 8)

    void removeLife(){
        trueSilverHp--;
    }   

    void OnCollisionEnter2D(Collision2D collision) {

        if(gameObject.name.StartsWith("truewhite--brick")){
        //remove one hp from truewhite--brick
            removeLife();
            if(trueSilverHp == 0){
                ScoreSystem.instance.AddPoints(50); //50 * level
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
    }
}