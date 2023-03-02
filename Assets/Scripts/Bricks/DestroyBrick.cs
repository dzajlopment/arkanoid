using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour{
    int trueSilverHp = 2;  //1 + (level / 8)

    void removeLife(){
        trueSilverHp--;
    }   

    void OnCollisionEnter2D(Collision2D collision) {
        if(gameObject.name.StartsWith("truewhite--brick")){
            removeLife();
            if(trueSilverHp == 0){
                ScoreSystem.instance.AddPoints(50); //50 * level
                Destroy(gameObject);
            }
        }
        else {
            Destroy(gameObject);
        }
    }
}