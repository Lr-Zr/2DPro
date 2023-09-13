using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 30.0f;

    public GameObject target = null;



    // Start is called before the first frame update
    void Start()
    {
        //this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate_1();
        //Rotate_2();
        //Rotate_3();
        //Rotate_4();
        Rotate_Around();
    }
    void Rotate_1()
    {
        Quaternion target = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        this.transform.rotation = target;
    }

    void Rotate_2()
    {
        this.transform.Rotate(Vector3.up * 45.0f);

    }

    void Rotate_3()
    {
        float rot = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up);

    }

        
    void Rotate_4()
    {
        float rot = speed * Time.deltaTime;
        this.transform.Rotate(rot * Vector3.up);

    }
    void Rotate_Around()//기준으로 돌아간다
    {
        
        float rot = speed * Time.deltaTime;
        //transform.RotateAround(new Vector3(0, 0.f, 0), Vector3.up, rot);
        transform.RotateAround(target.transform.position, Vector3.up, rot);
       

    }
}
