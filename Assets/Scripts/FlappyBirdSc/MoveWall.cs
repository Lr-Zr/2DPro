using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{


    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);

        if(transform.position.x <-15)
        {
            Destroy(gameObject);
        }
    }
}
