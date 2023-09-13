using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    float maxSpeed = 1500f;
    new SpriteRenderer renderer;

    public GameObject bullet = null;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        renderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //Flip_2D(x);
        Move_2(x,y);

        if(Input.GetKeyDown("k"))
        {
            if (time > 0.2)
            {
               Instantiate(bullet, transform.position, transform.rotation);
                time = 0;
            }
        }
        
    }

    void Move_1(float x, float y)
    {
        rigidBody.AddForce(new Vector2(x * maxSpeed * Time.deltaTime, y * maxSpeed * Time.deltaTime));
    }
    void Move_2(float x, float y)
    {
        Vector3 position = rigidBody.transform.position;
        
        position = new Vector3(
            position.x + (x * maxSpeed * Time.deltaTime)
            , position.y + (y * maxSpeed * Time.deltaTime)
            ,position.z);
        if (position.y < -150)
            position.y = -150;
        else if(position.y >200)
            position.y = 200;
        
        rigidBody.MovePosition(position);
    }
    void Flip_2D(float x)
    {
        if(Mathf.Abs(x)>0)
        {
            if(x>0)
            {
                renderer.flipX = false;
            }
            else
            {

                renderer.flipX = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {

        }
        else if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
        else if( collision.tag =="BulletE")
        {
            Destroy(collision.gameObject);
        }
    }

}
