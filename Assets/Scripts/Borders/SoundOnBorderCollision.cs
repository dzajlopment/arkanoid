using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnBorderCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        Sound.instance.playBallBounceSound();
    }
}
