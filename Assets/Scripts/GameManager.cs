using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns = 3;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    public static Vector3 jumpLabel = new Vector3();
    public static bool jumpLabelSet = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Start timer
        timer += Time.deltaTime;

        // Instantiate obstacles when the timer has exceeded timeBetweenSpawns,
        // and if the game has started and the player is alive
        if (timer > timeBetweenSpawns && StartButton.gameStarted &&
            PlayerMovement.alive)
        {
            timer = 0;
            int randNum = Random.Range(0, 3);
            GameObject newObstacle = Instantiate(spawnObject,
                spawnPoints[randNum].transform.position, Quaternion.identity);
            if (!jumpLabelSet)
            {
                jumpLabel = spawnPoints[randNum].transform.position;
                jumpLabelSet = true;
            }
            spawnedObjects.Add(newObstacle);

        }
        // Clean up/destroy game objects once the game state as returned to
        // the start state and the player is idle
        else if (StartButton.gameState == StartButton.IDLE)
        {
            if (spawnedObjects.Count > 0)
            {
                int n = spawnedObjects.Count;
                for (int i = 0; i < n; ++i)
                {
                    Destroy(spawnedObjects[i]);
                }
            }
            jumpLabelSet = false;
        }

        // Safety check to ensure timer is always positive
        if (timer < 0)
        {
            timer = 0;
        }

        if (timer % 5 == 0 && timer >= 0.5 && timeBetweenSpawns >= 1)
        {
            timeBetweenSpawns -= 0.5f;
        }
    }
}
