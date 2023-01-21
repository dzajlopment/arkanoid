using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;

public class Platform : MonoBehaviour {
    [SerializeField] float speed = 5f;
    [SerializeField] Vector2 launchDir = new Vector2(0, 1);

    Rigidbody2D rb;

    float leftBorderX = (float)-8.23;
    float rightBorderX = (float)8.23;

    bool mouseIsOnGameScreen() {
        if (EditorWindow.mouseOverWindow) {
            if(EditorWindow.mouseOverWindow.ToString() == " (UnityEditor.GameView)") {
                return true;
            }
        }
        return false;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float mouseInput = Input.GetAxis("Mouse X");
        rb.velocity = Vector2.right * horizontalInput * speed;

        //Moves the platform to the x mouse position when mouse movement is detected
        if (mouseInput != 0) {
            if (mouseIsOnGameScreen()) {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rb.transform.position = new Vector2(mousePosition.x, rb.position.y);
            }
        }

        //Disallow to move outside the borders
        //TO IMPROVE
        if (rb.position.x < leftBorderX) {
            rb.transform.position = new Vector2(leftBorderX, rb.position.y);
            return;
        }
        if (rb.position.x > rightBorderX) {
            rb.transform.position = new Vector2(rightBorderX, rb.position.y);
            return;
        }

        //Launches the ball if is grabbed by the platform
        if (transform.childCount > 0 && Input.GetButtonDown("Jump")) {
            BallVelocity ball = GetComponentInChildren<BallVelocity>();
            ball.Launch(launchDir);
        }
    }
}
