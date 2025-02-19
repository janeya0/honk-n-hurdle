using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(5 * -1, 0);
    }
}
