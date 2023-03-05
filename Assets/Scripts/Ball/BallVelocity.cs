using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BallVelocity : MonoBehaviour {
    public static BallVelocity instance;
    [SerializeField] float ballSpeed = 5f;
    Rigidbody2D rb2d;
    float hitAspect(Vector2 ballPosition, Vector2 racketPosition, float platformWidth) {
        return (ballPosition.x - racketPosition.x) / platformWidth;        
    }

    void Start() {
        //ball movement
        rb2d.velocity = Vector2.up * ballSpeed;
    }

    private void Awake() {
        instance = this;
        rb2d = GetComponent<Rigidbody2D>();
    }

    //launch the ball in the beginning of the level or if life's lost
    public void Launch(Vector2 dir) {
        transform.parent = null;
        rb2d.simulated = true;
        rb2d.velocity = dir.normalized * ballSpeed;
    }

    public void Catch(Transform parent) {
        transform.parent = parent;
        rb2d.simulated = false;
        rb2d.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "platform") {
            float aspect = hitAspect(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(aspect, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;
        }
    }
}
