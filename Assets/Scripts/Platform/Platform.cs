using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;
using System;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector2 launchDir = new Vector2(0, 1);

    Rigidbody2D rb;

    float leftBorderX = (float)-8.23;
    float rightBorderX = (float)8.23;
    float mouseInput;
    BoxCollider2D border;
    Vector2 size;
    Ray castPoint;

    bool mouseIsOnGameScreen(){
        if (EditorWindow.mouseOverWindow) {
            if (EditorWindow.mouseOverWindow.ToString() == " (UnityEditor.GameView)") {
                return true;
            }
        }
        return false;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        border = GetComponent<BoxCollider2D>();
        size = border.size;
    }

    void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        mouseInput = Input.GetAxis("Mouse X");
        rb.velocity = Vector2.right * horizontalInput * speed;

        //Get mouse world position
        castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        Single singleCastPoint = (Single)castPoint.origin.x;

        //Disallow to move outside the borders
        if (singleCastPoint < leftBorderX) {
            return;
        }
        if (singleCastPoint > rightBorderX) {
            return;
        }

        //Moves the platform to the x mouse position when mouse movement is detected
        if (mouseInput != 0) {
            if (mouseIsOnGameScreen()) {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rb.transform.position = new Vector2(mousePosition.x, rb.position.y);
            }
        }

        //Launches the ball if is grabbed by the platform
        if (transform.childCount > 0 && Input.GetButtonDown("Jump")) {
            BallVelocity ball = GetComponentInChildren<BallVelocity>();
            ball.Launch(launchDir);
        }
    }
}
