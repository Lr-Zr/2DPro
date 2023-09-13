using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Player2D : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CircleCollider2D circleCollider;
    float maxSpeed = 1500f;
    new SpriteRenderer renderer;

    public GameObject bullet = null;
    public GameObject bolt = null;
    public GameObject shield = null;
    public Image imgHPBar = null;
    public Image imgGage = null;




    float time = 0;
    float ftime = 0;
    float attacktime = 0;
    float gagetime = 0;


    bool hitted = false;
    bool energy = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        time = 0;
        hitted = false;

        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //>>>이동 관련>>
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        print(Input.GetAxis("Vertical"));
        //Flip_2D(x);

        Move_2(x, y);
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


        //>>공격>>>
        attacktime -= Time.deltaTime;
        if (Input.GetKeyDown("k"))
        {
            if (attacktime < 0)
            {
                var a = Instantiate(bullet, transform.position, transform.rotation);
                if (!GameMgr2D.Instance.onred)
                    a.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 1);
                attacktime = 0.6f;
            }
        }
        if (Input.GetKeyDown("j") && energy)
        {

            var a = Instantiate(bolt, transform.position, transform.rotation);
            if (!GameMgr2D.Instance.onred)
                a.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 1);
            gagetime = 0;
            energy = false;
        }

        //<<<<<
        ShowHPBar(GameMgr2D.Instance.playerHP);// 현재 hp


        if (time >= ftime + 3f)
        {

            hitted = false;
            if (shield)
                shield.SetActive(false);
        }
        if (!energy)
        {
            gagetime += Time.deltaTime;
            ShowGage(gagetime);
            if (gagetime > 10)
            {
                energy = true;

            }
        }


    }
    void ShowHPBar(int count)
    {
        imgHPBar.fillAmount = (float)count / 100f;
    }
    void ShowGage(float time)
    {
        imgGage.fillAmount = time / 10f;
    }




    void Move_1(float x, float y)
    {
        rigidBody.AddForce(new Vector2(x * maxSpeed * Time.deltaTime, y * maxSpeed * Time.deltaTime));
    }




    void Move_2(float x, float y)
    {
        print(x + ".." + y);
        Vector3 position = rigidBody.transform.position;

        position = new Vector3(
            position.x + (x * maxSpeed * Time.deltaTime)
            , position.y + (y * maxSpeed * Time.deltaTime)
            , position.z);
        if (position.y < -150)
            position.y = -150;
        else if (position.y > 200)
            position.y = 200;

        rigidBody.MovePosition(position);

    }
    void Flip_2D(float x)
    {
        if (Mathf.Abs(x) > 0)
        {
            if (x > 0)
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

        if (collision.tag == "Enemy" && !hitted)
        {
            GameMgr2D.Instance.playerHP -= 40;
            ftime = time;

            hitted = true;
            if(shield)
            shield.SetActive(true);


        }

        else if (collision.tag == "BulletE" && !hitted)
        {
            GameMgr2D.Instance.playerHP -= 20;
            ftime = time;
            hitted = true;
            if (shield)
                shield.SetActive(true);
        }
        else if (collision.tag == "Coin")
        {
            GameMgr2D.Instance.playerHP += 10;
            ///점수 얻기 
            GameMgr2D.Instance.score += 100;
        }
    }

}
