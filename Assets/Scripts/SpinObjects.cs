using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObjects : MonoBehaviour
{
    private float spinSpeed=30.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, spinSpeed * Time.deltaTime);
    }
}
