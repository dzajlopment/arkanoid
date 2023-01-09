using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BallVelocity : MonoBehaviour {
    public float ballSpeed = 5;

    float hitAspect(Vector2 ballPosition, Vector2 racketPosition, float platformWidth) {
        return (ballPosition.x - racketPosition.x) / platformWidth;        
    }

    void Start() {
        //ball movement
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "platform") {
            float aspect = hitAspect(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(aspect, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;
        }
    }
}
