﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp1 : MonoBehaviour
{
    public float speed;
    //private PlayerControllerX playerControllerScript;
      private float downBound = -30f;
    //-25.15193
    //-25.35193
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y<downBound){
            transform.position=startPosition;
        }
        
    }
}