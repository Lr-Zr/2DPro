using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3D : MonoBehaviour
{

    public GameObject target;


    NavMeshAgent agent;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;

        animator.SetFloat("Speed", agent.speed);

    }
    private void OnDrawGizmos()
    {
        if (agent == null)
            return;

            NavMeshPath path = agent.path;
            Gizmos.color = Color.blue;
            foreach (Vector3 corner in path.corners)
            {
                Gizmos.DrawSphere(corner, 0.4f);

            }
            Gizmos.color = Color.red;
            Vector3 pos = transform.position;
            foreach (Vector3 corner in path.corners)
            {
                Gizmos.DrawLine(pos, corner);
                pos = corner;
            }
        
    }
    void onJump()
    {
    }
    void OffJump()
    {
    }

    void onAttack()
    {
    }
    void onShoot()
    {

    }
    void offAttack()
    {

    }
    void onArrow()
    {
        //나중엔 객체 생성
    }
}
