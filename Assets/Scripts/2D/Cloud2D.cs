using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud2D : MonoBehaviour
{
    // Start is called before the first frame update
    float maxSpeed = 200f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * maxSpeed);

        if (transform.position.x < -500)
        {
            Destroy(gameObject);
        }
    }
}
