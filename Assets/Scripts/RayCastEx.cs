using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCastEx : MonoBehaviour
{
    [Range(0,50)]
    public float distance = 10.0f;
    private RaycastHit rayHit;
    private Ray ray;
    private RaycastHit[] rayHits;
    



    // Start is called before the first frame update
    void Start()
    {

        ray = new Ray();
        ray.origin = this.transform.position; //ray 시작점
        ray.direction = this.transform.forward;//어느방향으로
        //위와 같은 의미
        //ray = new Ray(this.transform.position, this.transform.forward);


    }

    // Update is called once per frame
    void Update()
    {

       
        Ray_4();

    }

    void Ray_1()
    {
        //충돌
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }
    void Ray_2()
    {
        //다중 충돌
        rayHits = Physics.RaycastAll(ray, distance);

        for(int index = 0; index<rayHits.Length; index++) 
        {
            Debug.Log(rayHits[index].collider.gameObject.name+"hit!");
        }
    }
    void Ray_3()
    {
        rayHits = Physics.SphereCastAll(ray, 10.0f, distance);
        string objName = "";
        foreach(RaycastHit hit in rayHits)
        {
            objName += hit.collider.name + ",";
            print(objName);

        }

    }

    void Ray_4()
    {

        ray.origin = this.transform.position; //ray 시작점
        ray.direction = this.transform.forward;//어느방향으로


        rayHits = Physics.RaycastAll(ray, distance);
        for(int index = 0; index<rayHits.Length;index++)
        {
            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Box"))//이름으로 layer
                Debug.Log(rayHits[index].collider.gameObject.name + "hit !! -Layer");

            if (rayHits[index].collider.gameObject.tag == "Sphere")
                Debug.Log(rayHits[index].collider.gameObject.name + "hit!! - Tag");
        }
    }
        private void OnDrawGizmos()
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        Gizmos.DrawLine(ray.origin, ray.direction * distance+ray.origin);
        Gizmos.color=Color.yellow;
        Gizmos.DrawSphere(ray.origin, 0.1f);


        if(this.rayHits !=null)
        {
            for(int i = 0; i<this.rayHits.Length;i++)
            {
                //collision point
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);//layer 충돌 부위

                // DrawLine
                Gizmos.color=Color.green;
                Gizmos.DrawLine(this.transform.position,this.transform.position+ transform.forward * rayHits[i].distance);

                //normal vector
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(this.rayHits[i].point, this.rayHits[i].point + this.rayHits[i].normal);

                // reflection vector
                Gizmos.color = new Color(1.0f, 0.0f, 1.0f);
                Vector3 reflect = Vector3.Reflect(this.transform.forward,
                                                this.rayHits[i].normal);
                Gizmos.DrawLine(this.rayHits[i].point, rayHits[i].point + reflect);
            }
        }

    }
}
