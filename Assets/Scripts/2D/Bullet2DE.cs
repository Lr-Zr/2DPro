using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2DE : MonoBehaviour
{

    float maxSpeed = 1300f;

    public GameObject hit;
    Rigidbody2D rigidBody;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        this.transform.position = new Vector3(this.transform.position.x - 100, this.transform.position.y, this.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(
            position.x - (maxSpeed * Time.deltaTime)
            , position.y
            , position.z);

        rigidBody.MovePosition(position);
        if (time > 3)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Palyer")
        {
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Bolt")
        {
            Destroy(this.gameObject);
            Instantiate(hit, transform.position, transform.rotation);
        }

    }
}
