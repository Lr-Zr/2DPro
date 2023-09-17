using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animation spartanKing;
    public AnimationClip IDLE;
    public AnimationClip RUN;
    public AnimationClip ATTACK;

    public float radius = 0f;
    public LayerMask layer;
    public Collider[] colliders;
    Collider nearbase;


    public GameObject objSword = null;

    public float runSpeed = 5.0f;

    bool isattacking = false;
    bool stop = true;
    bool isDead = false;
    float time = 3;


    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        objSword.SetActive(false);
        isattacking = false;
        time = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (time > 0)
        {
            time -= Time.deltaTime;
            return;
        }
        //범위안에 객체를 찾고 가장 가까운 것을 판별후 이동할것
        colliders = Physics.OverlapSphere(transform.position, radius, layer);

        if (colliders.Length > 0)
        {
         
            float distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach (Collider collider in colliders)
            {
                float tmp = Vector3.Distance(transform.position, collider.transform.position);
                if (tmp <= distance)
                {
                    distance = tmp;
                    nearbase = collider;
                }

            }
            stop = false;
        }
        else
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade(IDLE.name, 0.3f);
            stop = true;
        }


        if (!isattacking && !stop)
        {
            Vector3 basepos = nearbase.transform.position;
            basepos.y = transform.position.y;
            transform.LookAt(basepos);


            if (Vector3.Distance(transform.position, basepos) > 2.5)
            {
                spartanKing.wrapMode = WrapMode.Loop;
                spartanKing.CrossFade(RUN.name, 0.3f);
                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
                isattacking = false;

            }
            else
            {

                if (spartanKing[ATTACK.name].enabled == false)
                {

                    spartanKing.wrapMode = WrapMode.Once;
                    spartanKing.CrossFade(IDLE.name, 0.3f);
                }
                isattacking = true;
            }

        }


        if (isattacking && !stop)
        {
            StartCoroutine("Attack1");
            isattacking = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            print("왜 /");
            isDead = true;
            stop = false;
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("diehard");
            Destroy(this.gameObject, 3.0f);
            
        }
        else if (other.tag == "Wall"&&!isDead)
        {
            isattacking = true;
        }

    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }



    IEnumerator Attack1()
    {
        print("이거안해?");
        //if (spartanKing.IsPlaying(ATTACK.name) == true) yield break;//반복 방지
        if (spartanKing[ATTACK.name].enabled == true) yield break;

        objSword.GetComponent<BoxCollider>().enabled = true;
        objSword.SetActive(true);
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.CrossFade(ATTACK.name, 0.3f);
        float delayTime = spartanKing.GetClip(ATTACK.name).length - 0.3f;// 길이 가져오기
        yield return new WaitForSeconds(delayTime);

        
        objSword.SetActive(false);
        if(!isDead)
        { 
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(IDLE.name, 0.3f);
        
        }

    }
}
