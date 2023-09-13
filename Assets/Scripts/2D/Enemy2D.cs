using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy2D : MonoBehaviour
{
    float maxSpeed = 800f;
    Rigidbody2D rigidBody;
    int hp = 0;
    float time = 0;
    public GameObject bullet;
    public Image imgHPBar = null;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        hp = 100;
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

        ShowHPBar(hp);// ÇöÀç hp

        if (transform.position.x < -600)
        {
            Destroy(gameObject);
        }
        if (hp <=0)
        {

            Destroy(this.gameObject);
            
        }
    }

    void ShowHPBar(int count)
    {
        imgHPBar.fillAmount = (float)count / 100f;
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
            hp -= 30;
        }else if(collision.tag =="Bolt")
        {
            hp -= 100;
        }

    }
}
