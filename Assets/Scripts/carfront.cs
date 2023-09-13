using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class carfront : MonoBehaviour
{
    public float speed = 30.0f;
    // Start is called before the first frame update

 
    void Start()
    {
        speed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float rot = Time.deltaTime * speed;
        float dir = Input.GetAxis("Horizontal");
    
        float currentRotationY = (this.transform.localEulerAngles.y > 180) ? this.transform.localEulerAngles.y - 360 : this.transform.localEulerAngles.y;

        if (dir != 0)
        {
            
            this.transform.Rotate(new Vector3(1, 0, 0) * rot * dir);

            if (currentRotationY > +45.0f)

                this.transform.rotation = Quaternion.Euler(
                      transform.localEulerAngles.x
                    , transform.parent.transform.localEulerAngles.y + 45
                    , transform.parent.transform.localEulerAngles.z + 90);

            else if (currentRotationY < -45.0f)

                this.transform.rotation = Quaternion.Euler(
                   transform.localEulerAngles.x
                  // transform.parent.transform.localEulerAngles.x
                    , transform.parent.transform.localEulerAngles.y - 45
                    , transform.parent.transform.localEulerAngles.z + 90);


        }
        else
        {
            this.transform.rotation = Quaternion.Euler(
                   //transform.localEulerAngles.x
                   transform.localEulerAngles.x
                , transform.parent.transform.localEulerAngles.y
                , transform.parent.transform.localEulerAngles.z + 90);

        }





    }
}
