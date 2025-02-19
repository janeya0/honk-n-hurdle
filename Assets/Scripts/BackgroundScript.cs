using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartButton.gameStarted && PlayerMovement.alive && StartButton.gameState == StartButton.ALIVE)
        {
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        } else if (StartButton.gameState == StartButton.IDLE)
        {
            offset = 0;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

    }
}
