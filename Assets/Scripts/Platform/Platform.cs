using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector2 launchDir = new Vector2(0, 1);
    Rigidbody2D rb;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = Vector2.right * horizontalInput * speed;

        if(transform.childCount > 0 && Input.GetButtonDown("Jump")) {
            BallVelocity ball = GetComponentInChildren<BallVelocity>();
            ball.Launch(launchDir);
        }
    }
}
