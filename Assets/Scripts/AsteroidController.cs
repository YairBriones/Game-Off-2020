using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 2.0f;
    public float bound = -35;
    private float rotationSpeed;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(-10.0f,10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*speed);
        transform.Rotate(0,rotationSpeed,0);
        if(transform.position.y <= bound){
            Destroy(gameObject);
        }
    }
}