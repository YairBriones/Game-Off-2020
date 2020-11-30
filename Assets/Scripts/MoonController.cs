using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    //Lifes
    private int moonLives;

    //Shooting
    private float fireRate = 3.5f;    
    public GameObject[] moonAsteroids;
    private int asteroid;
    private Quaternion rotation;

    //Movement
    private bool hasArrived;
    private bool moveRight;
    public float bound = 10;
    private bool move;

    //Collision
    public ParticleSystem explosion;

    //GM
    private GameManager1 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>();
        fireRate = 3.5f;
        moonLives = 100;
        moveRight = true;
        move = false;
        hasArrived = false;
        StartCoroutine(WaitAndShoot());
    }
    private IEnumerator WaitAndShoot(){
        while(gameManager.isGameActive){
            yield return new WaitForSeconds(fireRate);
            LaunchAsteroid();
        }
    }

    private void LaunchAsteroid(){
        asteroid = Random.Range(0,2);
        // asteroid = 0;
        switch(asteroid){
            case 0:
                rotation = Quaternion.Euler(0, 0, 60);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 45);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 30);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 15);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -15);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -30);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -45);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -60);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
            break;
            case 1:
                rotation = Quaternion.Euler(0, 0, 40);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 20);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -20);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -40);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
            break;
            case 2:            
                rotation = Quaternion.Euler(0, 0, 65);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 50);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, 25);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -25);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -50);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
                rotation = Quaternion.Euler(0, 0, -65);
                Instantiate(moonAsteroids[asteroid], transform.position, rotation);
            break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive){
            if(!hasArrived){
                transform.Translate(Vector3.down* Time.deltaTime * 3);
                if(transform.position.y <= 4){
                    hasArrived = true;
                }
            }
            if(move){
                if(moveRight){
                    transform.Translate(Vector3.right* Time.deltaTime * 3);
                }else{
                    transform.Translate(Vector3.left* Time.deltaTime * 3);
                }
            }
            
            if(transform.position.x >= bound){
                moveRight = false;
            }else if(transform.position.x <= -bound){
                moveRight = true;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Projectile")){
            Destroy(other.gameObject);
            moonLives -= 1;
        }
        if(moonLives == 75){
            fireRate = 3.0f;
        }
        if(moonLives == 25){
            fireRate = 2.5f;        
        }
        if(moonLives == 50){
            move = true;
        }
        if(moonLives <= 0){
            explosion.Play();
            Destroy(this.gameObject);
            gameManager.WinGame();
        }
    }
}
