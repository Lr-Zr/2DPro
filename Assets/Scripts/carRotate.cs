using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carRotate : MonoBehaviour
{
    public float speed = 200.0f;
    carMove carmove;
    // Start is called before the first frame update
    private void Awake()
    {
        carmove = GetComponent<carMove>();
    }
    void Start()
    {
        speed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate_1();
    }

    void Rotate_1()
    {
        float rot = Time.deltaTime * speed;
        float dir = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        if (carmove.IsDriving() == true)
        {
            if (move > 0)

                this.transform.Rotate(rot * Vector3.up * dir);
            else if (move < 0)
                this.transform.Rotate(rot * Vector3.up * -dir);
        }


    }
}
