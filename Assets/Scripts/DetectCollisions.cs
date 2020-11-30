using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private float counter;
    private PlayerController player;
    public int pointValue;
    public GameObject dest_exp;
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player").GetComponent<PlayerController>();
    }

  
    private void OnTriggerEnter(Collider other){

        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            player.score++;
            explosion=Instantiate(dest_exp,transform.position,transform.rotation);
            Destroy(explosion, 2.0f);
            Destroy(other.gameObject);
            player.UpdateScore(pointValue);
        }
    }
}
