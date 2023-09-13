using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletbolt2D : MonoBehaviour
{
    GameObject Player;
    public GameObject hit;
    float maxSpeed = 1300f;
    Rigidbody2D rigidBody;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Player = GameObject.Find("Player");
        this.transform.position = new Vector3(Player.transform.position.x + 120, Player.transform.position.y, Player.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(
            position.x + (maxSpeed * Time.deltaTime)
            , position.y
            , position.z);

        rigidBody.MovePosition(position);
        if (time > 4)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Vector3 pos = collision.transform.position;
            pos.x -= 20;
            Instantiate(hit, pos, transform.rotation);
            GameMgr2D.Instance.score += 10;
        }

    }
}
