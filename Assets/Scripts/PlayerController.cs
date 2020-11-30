using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    private float speed= 10.0f;

    private float xRange=12.0f;
    private float yRange=5.5f;
    //private float rotateSpeed= 10.0f;
    public float horizontalInput;
    public float forwardInput;

    public GameObject projectilePrefab;
    private GameManager gameManager;
    private float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public bool gameover=false;

    public int lifes = 3;

    public float score = 0;
    public ParticleSystem explosion; 

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        UpdateScore(0);
        //explosion.Stop();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive){
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

            if(lifes==2){
                life3.gameObject.SetActive(false);
            }else if(lifes==1){
                life2.gameObject.SetActive(false);
            }else if(lifes==0){
                life1.gameObject.SetActive(false);
                gameManager.GameOver();
            }

            if(transform.position.z != -4.7734){
                transform.position = new Vector3(transform.position.x,transform.position.y,-4.7734f);
            }
            transform.rotation = Quaternion.Euler(-90, 0, 0);

            if(score==50){
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void OnCollisionEnter(Collision other){
        lifes--;
        explosion.Play();
        Destroy(other.gameObject);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
