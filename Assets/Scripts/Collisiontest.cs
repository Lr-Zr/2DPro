using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisiontest : MonoBehaviour
{
    float speedMove = 10.0f;
    float speedRotate = 200.0f;
    Rigidbody rigidbody;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //float rot = Input.GetAxis("Horizontal");
        //float move = Input.GetAxis("Vertical");

        //rot = rot * speedRotate * Time.deltaTime;//ȸ��
        //move = move *speedMove*Time.deltaTime;

        //this.gameObject.transform.Rotate(Vector3.up * rot);
        //this.gameObject.transform.Translate(Vector3.forward * move);


        




    }
    private void FixedUpdate()
    {
        float rot = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        Quaternion deltaRot = Quaternion.Euler(new Vector3(0, rot, 0) * speedRotate * Time.deltaTime);
        //rotation
        rigidbody.MoveRotation(rigidbody.rotation * deltaRot);

        //movement
        Vector3 movement = transform.forward * move;
        Vector3 newPos = rigidbody.position + movement * speedMove * Time.deltaTime;
        rigidbody.MovePosition(newPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collision �浹 ����" + hitObject.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collision �浹�� " + hitObject.name);
    }
    private void OnCollisionExit(Collision collision) 
    {
        GameObject hitObject = collision.gameObject;
        print("Collision �浹�� " + hitObject.name);
    }

    //�����̴� �ʿ� rigidbody trigger�� �����־����;
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 ���� " + hitObject.name);
    }
    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 �� " + hitObject.name);
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 �� " + hitObject.name);
    }
}
