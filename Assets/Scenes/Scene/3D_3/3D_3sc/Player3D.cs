using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Player3D : MonoBehaviour
{
    public float runSpeed = 10.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;


    Animator animator;


    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        // CharacterController_Slerp();
        NavMesh_Control();
    }
    private void NavMesh_Control()
    {
        if(Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) )
            {
                //agent.destination = hit.point;
                agent.SetDestination(hit.point);

            }
            else
            {

            }
                pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);
                animator.SetFloat("Speed", agent.speed);

        }
    }
    private void FixedUpdate()
    {

        animator.SetFloat("Speed", agent.speed);
    }
    private void CharacterController_Slerp()
    {
     
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward
                , direction
                , rotationSpeed * Time.deltaTime /
                Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        else
        {

        }

        //애니메이션 파라미터이름 ,넘길 값;
        animator.SetFloat("Speed", pcController.velocity.magnitude);



        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);


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
