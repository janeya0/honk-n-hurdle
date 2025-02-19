using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jump;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator anim;
    public static bool alive = true;
    public static bool showExclamation = false;
    public float finishGameTimer = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        // Game started
        if (StartButton.gameStarted)
        {
            finishGameTimer += Time.deltaTime;

            if (finishGameTimer > 140)
            {
                anim.SetBool("running", false);
                StartButton.gameState = StartButton.IDLE;
                StartButton.gameStarted = false;

                StartLevel();

            }
            // Jumping
            if (Input.GetButtonDown("Jump") && isGrounded && alive)
            {
                rb.velocity = new Vector2(0, jump);
            }

            if (alive && anim.GetBool("running") == true)
            {
                rb.velocity = new Vector2(0.25f, rb.velocity.y);

            }
        }
        // Exclamation state
        else if (!StartButton.gameStarted && StartButton.timerGuy > 2)
        {
            anim.SetBool("running", true);
            showExclamation = true;
            StartButton.gameState = StartButton.ALIVE;
        }

        // Game over
        if (!alive && Input.GetButtonDown("Jump"))
        {
            StartLevel();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // Hits obstacle
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        alive = false;
        Time.timeScale = 0.0f;
        GameObject.FindGameObjectWithTag("Gameover")
            .GetComponent<SpriteRenderer>().enabled = true;
    }

    public void StartLevel()
    {
        StartButton.gameState = StartButton.IDLE;
        alive = true;
        StartButton.gameStarted = false;
        anim.SetBool("running", false);
        rb.velocity = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Gameover")
            .GetComponent<SpriteRenderer>().enabled = false;
        finishGameTimer = 0;
        Time.timeScale = 1.0f;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }
}
