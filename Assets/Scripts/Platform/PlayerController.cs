using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            transform.position = new Vector2(transform.position.x+0.08f, transform.position.y);
        } 
        else if (Input.GetKey("a"))
        {
            transform.position = new Vector2(transform.position.x - 0.08f, transform.position.y);
        }
    }
}
