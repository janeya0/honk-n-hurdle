using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool positionIsSet = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartButton.gameStarted && GameManager.jumpLabelSet && !positionIsSet)
        {
            transform.position = new Vector3(GameManager.jumpLabel.x, GameManager.jumpLabel.y + 2, 0);
            positionIsSet = true;
        } else if (positionIsSet)
        {
            rb.velocity = new Vector2(-5, 0);
        }

        if (StartButton.gameState == StartButton.IDLE)
        {
            positionIsSet = false;
        }
    }
}
