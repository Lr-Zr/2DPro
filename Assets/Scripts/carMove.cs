using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    bool isdriving = false;

    Rigidbody rigidbody = null;


    public int Lap = 0;
    public int points = 0;
    bool wall = false;
    void Start()
    {
        moveSpeed = 20.0f;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Move_Control();

    }

    void Move_Control()
    {

       
        if (Lap < 3)
        {
            float move = Input.GetAxis("Vertical");
            if (move != 0)
            {
                isdriving = true;
                Vector3 movement = transform.forward * move;
                Vector3 newPos = rigidbody.position + movement * moveSpeed * Time.deltaTime;
                rigidbody.MovePosition(newPos);
            }
            else
            {
                isdriving = false;
            }
            //float move = Input.GetAxis("Vertical");
            //if (move != 0)
            //{
            //    isdriving = true;
            //    this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * move);
            //}
            //else
            //{
            //    isdriving = false;
            //}
        }

    }
   
    public bool IsDriving() { return isdriving; }

    private void FixedUpdate()
    {
       Move_Control();

        // float move = Input.GetAxis("Vertical");
        // Quaternion deltaRot = Quaternion.Euler(new Vector3(0, , 0) * rotateSpeed * Time.deltaTime);
        //rotation
        //rigidbody.MoveRotation(rigidbody.rotation * deltaRot);

        //movement
        //Vector3 movement = transform.forward*move;
        //Vector3 newPos = rigidbody.position + movement * moveSpeed * Time.deltaTime;
        //rigidbody.MovePosition(newPos);
    }
    private void OnTriggerEnter(Collider other)
    {

        GameObject hitObject = other.gameObject;
        if (hitObject.name == "Line")
        {
            if (points == 6)
            {
                if (Lap < 3)
                {
                    Lap++;
                    points = 0;
                }

            }
        }
        else if (hitObject.name == "Point")
        {
            if (points == 0)
            { points++; }
        }
        else if (hitObject.name == "Point1")
        {
            if (points == 1)
            { points++; }
        }
        else if (hitObject.name == "Point2")
        {
            if (points == 2)
            { points++; }
        }
        else if (hitObject.name == "Point3")
        {
            if (points == 3)
            { points++; }
        }
        else if (hitObject.name == "Point4")
        {
            if (points == 4)
            { points++; }
        }
        else if (hitObject.name == "Point5")
        {
            if (points == 5)
            { points++; }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.name == "Wall")
        {
            wall = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.name == "Wall")
        {
            wall = false;
        }
    }
}
