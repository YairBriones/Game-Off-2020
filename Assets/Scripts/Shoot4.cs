using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot4 : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Quaternion rotation;
    private float startDelay = 1.0f;
    private float spawnInterval=2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", startDelay, spawnInterval); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchProjectile(){
        rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(projectilePrefab,transform.position,rotation);
        rotation = Quaternion.Euler(0, 0, 90);
        Instantiate(projectilePrefab,transform.position,rotation);
        rotation = Quaternion.Euler(0, 0, -90);
        Instantiate(projectilePrefab,transform.position,rotation);  
        rotation = Quaternion.Euler(0, 0, 180);
        Instantiate(projectilePrefab,transform.position,rotation);
    }
}
