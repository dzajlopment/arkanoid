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
        float mouseInput = Input.GetAxis("Mouse X");
        rb.velocity = Vector2.right * horizontalInput * speed;

        //Moves the platform to the x mouse position when mouse movement is detected
        if (mouseInput != 0) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.transform.position = new Vector2(mousePosition.x, rb.position.y);
        }

        //Launches the ball if is grabbed by the platform
        if (transform.childCount > 0 && Input.GetButtonDown("Jump")) {
            BallVelocity ball = GetComponentInChildren<BallVelocity>();
            ball.Launch(launchDir);
        }
    }
}
