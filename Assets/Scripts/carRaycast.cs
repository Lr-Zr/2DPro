using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carRaycast : MonoBehaviour
{


    [Range(0, 50)]
    public float distance = 30.0f;
    private RaycastHit rayHit1, rayHit2, rayHit3;
    private Ray ray1, ray2, ray3;
    private RaycastHit[] rayHits;

    public float moveSpeed = 10.0f;
    public float rotateSpeed = 100.0f;

    bool Wall = false;
    bool frontcar = false;
    int dir = 0;

    Rigidbody rigidbody;
    public float fray1 = 0;
    public float fray2 = 0;

    public int Lap = 0;
    public int points = 0;
    bool back = false;
    Vector3 saveforward;
    // Start is called before the first frame update
    private float time = 0;
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        Vector3 pos = transform.position;

        pos.y += -2;
        Vector3 dir1 = new Vector3(1, 0, 1);

        ray1 = new Ray(pos, dir1);
        dir1 = new Vector3(-1, 0, 1);
        ray2 = new Ray(pos, dir1);

        pos = transform.position;
        dir1 = this.transform.forward;
        ray3 = new Ray(pos, dir1);


    }

    // Update is called once per frame
    void Update()
    {
        if (Lap < 3)
        {
            initpos();
            raymove();
        }
    }

    //private void FixedUpdate()
    //{

    //    Quaternion deltaRot = Quaternion.Euler(new Vector3(0, dir, 0) * rotateSpeed * Time.deltaTime);
    //    //rotation
    //    rigidbody.MoveRotation(rigidbody.rotation * deltaRot);

    //    //movement
    //    Vector3 movement = transform.forward;
    //    Vector3 newPos = rigidbody.position + movement * moveSpeed * Time.deltaTime;
    //    rigidbody.MovePosition(newPos);
    //}






    void initpos()
    {
        time += Time.deltaTime;
        Vector3 pos = transform.position;
        pos.y += -2;
        Vector3 dir1 = (this.transform.forward + this.transform.right * -1).normalized;

        ray1.origin = pos;
        ray1.direction = dir1;

        dir1 = (this.transform.forward + this.transform.right).normalized;
        ray2.origin = pos;
        ray2.direction = dir1;


        pos = transform.position;
        dir1 = this.transform.forward;
        ray3.origin = pos;
        ray3.direction = dir1;
    }





    void raymove()

    {

        moveSpeed = 10.0f + UnityEngine.Random.Range(1f, 8f);
        rotateSpeed = 200f;
        if (Wall)
        {
            moveSpeed = 8.0f;
        }
        frontcar = false;
        float gap = 1;



        if (Physics.Raycast(ray1.origin, ray1.direction, out rayHit1, distance))
        {
            if (rayHit1.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                fray1 = Vector3.Distance(rayHit1.point, ray1.origin);

                //Debug.Log("1----------------------"+fray1);
            }
            else
            {
                print(rayHit2.collider.gameObject.name);
            }
        }
        if (Physics.Raycast(ray2.origin, ray2.direction, out rayHit2, distance))
        {
            if (rayHit2.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                //Vector3 reflect = Vector3.Reflect(transform.forward, rayHit2.normal);//반사각
                //핸들을 좌우

                fray2 = Vector3.Distance(rayHit2.point, ray2.origin);

            }
            else
            {
                print(rayHit2.collider.gameObject.name);
            }

        }
        if (Physics.Raycast(ray3.origin, ray3.direction, out rayHit3, 5))
        {
            if (rayHit3.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                //Debug.Log("3----------------------" + fray3);
                moveSpeed = 3.0f;
                gap = 0;
                rotateSpeed = 300;
            }
            else if (rayHit3.collider.gameObject.layer == LayerMask.NameToLayer("Car"))
            {
                frontcar = true;
                rotateSpeed = 300;
                gap = 0;

            }
        }

        //if (frontcar)
        //{
        //    if (UnityEngine.Random.Range(0, 1) == 1)
        //    {
        //        fray1 = 0;

        //    }
        //    else
        //        fray2 = 0;

        //}
        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);


        if (fray1 == 0 && fray2 == 0)
        {
            dir = 0;
        }
        else if (fray1 - fray2 > gap || fray1 == 0)
        {
            dir = -1;
            this.transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.up * dir);

            //Debug.Log("1----------------------" + fray1 + " --- "+fray2);
        }
        else if (fray1 - fray2 < -gap || fray2 == 0)
        {
            dir = 1;
            this.transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.up * dir);
            //Debug.Log("2----------------------" + fray1 + " --- " + fray2);
        }
        else
        {
            dir = 0;
        }






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
            Wall = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.name == "Wall")
        {
            Wall = false;
        }
    }



    private void OnDrawGizmos()
    {
        //collision point


        Gizmos.DrawLine(ray1.origin, ray1.direction * distance + ray1.origin);
        Gizmos.DrawLine(ray2.origin, ray2.direction * distance + ray2.origin);
        Gizmos.DrawLine(ray3.origin, ray3.direction * 1 + ray3.origin);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rayHit1.point, 0.1f);//layer 충돌 부위
        Gizmos.DrawSphere(rayHit2.point, 0.1f);//layer 충돌 부위
        Gizmos.DrawSphere(rayHit3.point, 0.1f);//layer 충돌 부위


        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray1.origin, 0.1f);


    }
}
