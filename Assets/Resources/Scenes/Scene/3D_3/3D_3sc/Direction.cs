using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{

    public GameObject item;


    // Start is called before the first frame update
    void Start()
    {

        this.transform.LookAt(item.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.LookAt(item.transform.position);
        this.transform.Rotate(new Vector3(0,90,0));
    }
}
