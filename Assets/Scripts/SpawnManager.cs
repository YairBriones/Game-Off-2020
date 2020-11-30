using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnrangeX=12;
    private float spawnPosY=5;
    private float startDelay=2;
    private float spawnInterval=1.5f;
    private PlayerController player;
    private float spawnPosZ= -4.7734f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player=GameObject.Find("Player").GetComponent<PlayerController>();
        //InvokeRepeating("SpawnRandomEnemy",startDelay, spawnInterval);
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy(){
            int randomEnemy=Random.Range(0,enemyPrefabs.Length);
            Vector3 spawPos= new Vector3(Random.Range(-spawnrangeX, spawnrangeX),spawnPosY,spawnPosZ);
            Instantiate(enemyPrefabs[randomEnemy],spawPos,enemyPrefabs[randomEnemy].transform.rotation);
    }

    public IEnumerator SpawnEnemy(){
        while(true){
            if(player.score < 15){
                spawnInterval=1.5f;
            }else if (player.score >= 15 && player.score <35){
                spawnInterval=1.25f;
            }else{
                spawnInterval=1.0f;
            }
                yield return new WaitForSeconds(spawnInterval);
            if(gameManager.isGameActive){
                SpawnRandomEnemy();
            }
        }
    }
}
