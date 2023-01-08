using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocity : MonoBehaviour
{
    public float ballSpeed = 5;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }
}
