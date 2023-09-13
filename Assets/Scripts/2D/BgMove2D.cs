using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove2D : MonoBehaviour
{
    float maxSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(-maxSpeed * Time.deltaTime, 0, 0));

        if(this.transform.position.x<=-1920)
        {
            this.transform.Translate(new Vector3(1920 + maxSpeed * Time.deltaTime, 0, 0));

        }
    }
}
