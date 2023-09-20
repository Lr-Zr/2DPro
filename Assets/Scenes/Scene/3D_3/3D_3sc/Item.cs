using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Item : MonoBehaviour
{
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    Vector3[] pos = new Vector3[4];
    int cur = 0;
    void Start()
    {
        pos[0] = new Vector3(-35, 3, -35);
        pos[1] = new Vector3(45, 3, -45);
        pos[2] = new Vector3(45, 3, 45);
        pos[3] = new Vector3(-45, 3, 45);
        //this.transform.position = pos[cur];
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        float temp = Time.time * 100f;

        Random.InitState((int)temp);
        print("pass");
        while (true)
        {
            int itmp = Random.Range(0, 4);
            if (itmp != cur)
            {
                cur = itmp;
                break;
            }
        }
        this.transform.position = pos[cur];
        GameMgr3D_3.Instance.cnt--;
        if (other.tag == "Player")
            GameMgr3D_3.Instance.score += 666;
        m_AudioSource.Play();

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("pass2");
    }
}
