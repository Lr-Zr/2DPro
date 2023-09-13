using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    void Start()
    {
        this.transform.position = new Vector3(0.0f, 0.5f, 0.0f); // world 좌표 기준 .
        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f)); // local 기준

    }

    // Update is called once per frame
    void Update()
    {
        //Move_1();
        //Move_2();

        Move_Control();
    }

    void Move_1()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;

        Vector3 pos = this.transform.position;//
        pos.z += moveDelta;
        this.transform.position = pos;
    }
    void Move_2()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta);//forward  0,0,1;

    }

    void Move_Control()
    {
        float move = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * move);

        float move2 = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.right* Time.deltaTime * moveSpeed * move2);
    }

}
