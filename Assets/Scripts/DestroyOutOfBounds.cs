using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float lowerBound=-6.0f;
    private float xBound=13.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>-lowerBound){
            Destroy(gameObject);
        }else if (transform.position.y<lowerBound)
        {
            Destroy(gameObject);
        }else if(transform.position.x>xBound){
            Destroy(gameObject);
        }else if(transform.position.x<-xBound){
            Destroy(gameObject);
        }
    }
}
