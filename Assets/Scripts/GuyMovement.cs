using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dist = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartButton.startTimer == true)
        {
            if (dist > 10)
            {
                transform.position = new Vector3(rb.position.x, rb.position.y, 20);
            }
            else
            {
                rb.velocity = new Vector2(2f, 0);
                dist += Time.deltaTime;
            }
        } else if (StartButton.gameState == StartButton.IDLE)
        {
            rb.velocity = new Vector2(0, 0);
            dist = 0;
            transform.position = new Vector3(1.66f, -1.84f  , 0);
        }
        
    }
}
