using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    
    private Vector3 startPos;
    private float speed = 5;
    public GameObject background;
    private bool created = false;
    private void Start()
    {
        startPos = new Vector3(0,36.5f,0);// Establish the default starting position 
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.y < -23 && !created)
        {
            Instantiate(background, startPos, background.transform.rotation);
            created = true;
        }

        if(transform.position.y < -37)
        {
            Destroy(gameObject);
        }
    }
}
