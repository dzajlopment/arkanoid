using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            // GO TO NEXT LEVEL SHIT
            Debug.Log("Level over");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
