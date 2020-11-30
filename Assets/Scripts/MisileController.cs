using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 7.0f;
    public float bound = 12.0f;
    public GameObject explosion;
    private GameObject explosionMisile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
        
        if(transform.position.y >= bound){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")){
            explosionMisile = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            Destroy(explosionMisile, 2.0f);
        }else if(other.gameObject.CompareTag("Moon")){
            explosionMisile = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosionMisile, 2.0f);
        }
    }
}
