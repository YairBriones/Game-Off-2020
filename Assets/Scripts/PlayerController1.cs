using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{   
    //Movement
    private float speed= 10.0f;    
    public float horizontalInput;
    public float forwardInput;
    private bool canMoveAndShoot;
    private Rigidbody playerRB;

    //Lifes
    private int lifes;
    public GameObject[] lifeSprites;

    //Bounds
    private float xRange=12.0f;
    private float yRange=5.5f;

    //Misile
    public GameObject projectilePrefab;

    //GM
    private GameManager1 gameManager;

    //Fire Rate
    private float fireRate = 0.35f;
    private float nextFire;

    //Explosions on collision
    public ParticleSystem explosion;
    public ParticleSystem bigExplosion;

    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        nextFire = 0.0f;
        canMoveAndShoot = false;
        playerRB = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive){
            if(transform.position.z != -5){
                transform.position = new Vector3(transform.position.x,transform.position.y,-5);
            }
            //transform.rotation = Quaternion.Euler(-90, 0, 0);
            if(canMoveAndShoot){
                if(Input.GetKeyDown(KeyCode.Space)){
                    if(Time.time>nextFire){
                        nextFire = Time.time + fireRate;
                        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                    }else{
                        Debug.Log("Espera antes de volver a disparar");
                    }
                }
                if(transform.position.x <= -xRange){
                    transform.position=new Vector3(-xRange,transform.position.y,transform.position.z);
                }
                if(transform.position.x >= xRange){
                    transform.position=new Vector3(xRange,transform.position.y,transform.position.z);
                }
                if(transform.position.y <= -yRange){
                    transform.position=new Vector3(transform.position.x,-yRange,transform.position.z);
                }
                if(transform.position.y >= yRange){
                    transform.position=new Vector3(transform.position.x,yRange,transform.position.z);
                }
                horizontalInput=Input.GetAxis("Horizontal");
                forwardInput=Input.GetAxis("Vertical");
                transform.Translate(Vector3.forward*Time.deltaTime*forwardInput*speed);
                transform.Translate(Vector3.right*Time.deltaTime*horizontalInput*speed);
            }else{
                transform.Translate(Vector3.forward*Time.deltaTime*3);
                if(transform.position.y >= -5){
                    canMoveAndShoot = true;
                }
            }     
        }
       
    }
    private void OnTriggerEnter(Collider other) {
        if(gameManager.isGameActive){
            if(other.gameObject.CompareTag("Enemy")){
                explosion.Play();
                Destroy(other.gameObject);
                lifes -= 1;
                Destroy(lifeSprites[lifes]);
            }else if(other.gameObject.CompareTag("Moon")){
                lifes = 0;
            }
            if(lifes <= 0){
                bigExplosion.Play();
                gameManager.GameOver();
                playerRB.useGravity = true;
                Destroy(gameObject,3.0f);
            } 
        }
        
    }
}
