using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookAt : MonoBehaviour
{

    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt_3();
    }

    void LookAt_1()
    {
        Vector3 dirTotarget= target.transform.position - this.transform.position;
        this.transform.forward = dirTotarget.normalized;
    }
    
    void LookAt_2()
    {
        Vector3 dirTotarget = target.transform.position - this.transform.position;
        this.transform.LookAt(dirTotarget);//함수이용
    }

    void LookAt_3()
    {

        Vector3 dirTotarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(dirTotarget, Vector3.up);
    }
}
