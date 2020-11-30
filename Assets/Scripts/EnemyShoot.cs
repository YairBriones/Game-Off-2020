using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float fireRate = 20.0F;
    private float nextFire = 1.0F;
    public float speed=2.0f;
    private float spawnRange=9.0f;
    private float startDelay = 1.0f;
    private float spawnInterval=4.0f;
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
        spawnInterval=Random.Range(0,0.2f);
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);    
    }
}
