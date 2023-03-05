using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    public GameObject powerupCapsule; //for spawning of powerup capsules

    void OnCollisionEnter2D(Collision2D collision) {
        if (Powerups.shouldPowerupSpawn && Powerups.areEnoughPoints)
        {
            GameObject capsule = Instantiate(powerupCapsule, gameObject.transform);
            capsule.transform.parent = gameObject.transform.parent;
            capsule.transform.position = new Vector2(capsule.transform.position.x + 4.48f, transform.position.y);
        }
        Destroy(gameObject);

    }
}