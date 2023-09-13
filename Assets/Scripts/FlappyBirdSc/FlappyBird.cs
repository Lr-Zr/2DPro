using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public float jumpPower = 10.0f;
    Vector3 basicpos;
    // Start is called before the first frame update
    Rigidbody rigidbody;
    GameObject obj;

    bool hitted=false;
    float time = 0;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        basicpos = transform.position;
        obj = GameObject.Find("Game");
    }

    // Update is called once per frame
    void Update()

    {

        transform.rotation = Quaternion.Euler(-2.5f * rigidbody.velocity.y, 90, 0);
        float currentRotationX = (transform.eulerAngles.x > 180) ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;

        if (currentRotationX > 25)
            transform.rotation = Quaternion.Euler(25, 90, 0);
        else if (currentRotationX < -20)
            transform.rotation = Quaternion.Euler(-50, 90, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            //  transform.rotation = Quaternion.Euler(-20, 90, 0);
        }

        if(hitted)
        {
            time += Time.deltaTime;
            if(time>3)
            {
                hitted = false;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
        


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Item(Clone)")
        {
            obj.GetComponent<FlappyGame>().AddScore();
            Destroy(other.gameObject);
        }
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall(Clone)")
        {
            transform.position = basicpos;
            hitted = true;
            time = 0;
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }
}
