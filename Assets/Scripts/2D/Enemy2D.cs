using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    float maxSpeed = 1000f;
    Rigidbody2D rigidBody;
    int life = 3;
    float time = 0;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move_1();
        time += Time.deltaTime; 
        if (time > 2.0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            time = 0;
        }

        if (transform.position.x < -600)
        {
            Destroy(gameObject);
        }
    }
        private void Move_1()
        {
            Vector3 position = transform.position;

            position = new Vector3(
                position.x - (maxSpeed * Time.deltaTime)
                , position.y
                , position.z);


            rigidBody.MovePosition(position);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Bullet")
            {
                life--;
                Destroy(collision.gameObject);
                if (life <= 0)
                {
                    Destroy(this.gameObject);

                }
            }
        }
    }
