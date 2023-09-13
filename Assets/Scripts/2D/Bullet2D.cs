using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : MonoBehaviour
{
    GameObject obj;

    float maxSpeed = 1000f;
    Rigidbody2D rigidBody;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        obj = GameObject.Find("Player");
        this.transform.position=new Vector3(obj.transform.position.x+120,obj.transform.position.y,obj.transform.position.z);
     
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(
            position.x + ( maxSpeed * Time.deltaTime)
            , position.y 
            , position.z);

        rigidBody.MovePosition(position);
        if(time>3)
        {
            Destroy(this.gameObject);
        }
    }


   
}
