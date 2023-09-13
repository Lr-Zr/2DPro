using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2D : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y =Random.Range(-200f, 200f);
        this.transform.position=new Vector3(550,y,0); 
    }
}
