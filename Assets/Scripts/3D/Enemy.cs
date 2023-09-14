using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animation spartanKing;

    public GameObject objSword = null;




    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        objSword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            spartanKing.Play("diehard");
        }
            print(other.tag);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Sword")
        {
            spartanKing.Play("diehard");
        }
        print(collision.collider.tag);

    }

}
