using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource src;
    // public AudioClip ballBounce, destroyedBrick, goldBrickHit;
    public AudioClip ballBounce, destroyedBrick, goldBlockHit;

    public static Sound instance;

    void Awake() {
        src = GetComponent<AudioSource>();
        instance = this;
        // destroyedBrick = GetComponent<AudioClip>();
    }  

    public void playBallBounceSound() {
        src.clip = ballBounce;
        src.Play();
    }

    public void playDestroyedBrickSound() {
        src.clip = destroyedBrick;
        src.Play();
    }

    public void playGoldBlockHitSound() {
        src.clip = goldBlockHit;
        src.Play();
    }

}
