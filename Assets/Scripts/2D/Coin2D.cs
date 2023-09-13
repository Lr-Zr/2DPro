using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(Random.Range(-150f, 300f), Random.Range(-200f, 200f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; 
        if(time>10)
        {
            Destroy(gameObject);
        }
    }

  
}
