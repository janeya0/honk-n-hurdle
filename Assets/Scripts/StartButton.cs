using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public static Rigidbody2D rbStart;
    public static bool gameStarted;
    public static int gameState;
    public static int IDLE = 1;
    public static int ALIVE = 2;
    public static int DEAD = 3;
    public static float timerGuy;
    public static bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        rbStart = GetComponent<Rigidbody2D>();
        gameStarted = false;
        gameState = IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == IDLE || gameState == DEAD)
        {
            gameStarted = false;
            transform.position = new Vector3(rbStart.position.x, rbStart.position.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                startTimer = true;
                gameState = ALIVE;
                transform.position = new Vector3(rbStart.position.x, rbStart.position.y, 20);

            }
        }

        if (startTimer == true)
        {
            timerGuy += Time.deltaTime;
        }

        if (startTimer == true && timerGuy > 5)
        {
            startTimer = false;
            gameStarted = true;
            timerGuy = 0;
        }

        
    }
}
