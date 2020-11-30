using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
    public float speed=2.0f;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.up*Time.deltaTime*speed);
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            player.lifes--;
            player.explosion.Play();
        }
    }
}
