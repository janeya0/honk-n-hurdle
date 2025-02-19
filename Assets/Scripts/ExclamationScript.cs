using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationScript : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.showExclamation)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                transform.position = new Vector3(-6.31f, -0.35f, 20);
                PlayerMovement.showExclamation = false;
                timer = 0;
            } else
            {
                transform.position = new Vector3(-6.31f, -0.35f, 0);
            }
        } else
        {
            transform.position = new Vector3(-6.31f, -0.35f, 20);
        }
    }
}
