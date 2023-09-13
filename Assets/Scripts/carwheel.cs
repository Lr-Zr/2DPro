using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carwheel : MonoBehaviour
{
    public float speed = 500.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float rot = speed * Time.deltaTime;
        this.transform.Rotate(rot * Vector3.up*-move);
    }
}
