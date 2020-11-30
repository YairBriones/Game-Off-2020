using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    private float randomRange;
    public float range = 8.0f;
    private Vector3 position;
    public GameObject asteroidPrefab;
    private GameManager1 gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>();
        InvokeRepeating("LaunchAsteroid", 0.5f, 0.5f);
    }

    private void LaunchAsteroid(){
        if(gameManager.isGameActive){
            randomRange = Random.Range(-range,range);
            position = new Vector3(randomRange, 10, -5);
            Instantiate(asteroidPrefab, position, asteroidPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
