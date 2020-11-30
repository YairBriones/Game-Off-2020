using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot3 : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Quaternion rotation;
    private float startDelay = 1.0f;
    private float spawnInterval=2.0f;

    
    void Start()
    {
        InvokeRepeating("LaunchProjectile", startDelay, spawnInterval); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LaunchProjectile(){
        rotation = Quaternion.Euler(0, 0, -240);
        Instantiate(projectilePrefab,transform.position,rotation);
        rotation = Quaternion.Euler(0, 0, -120);
        Instantiate(projectilePrefab,transform.position,rotation);
        rotation = Quaternion.Euler(0, 0, -180);
        Instantiate(projectilePrefab,transform.position,rotation);  
    }
}
