using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Player3D : MonoBehaviour
{
    public float runSpeed = 10.0f;
    public float mouseSpeed = 5f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;


    Animator animator;


    NavMeshAgent agent;

    public AudioClip audioclip = null;
    private AudioSource audioSource = null;

    public GameObject bow;
    public GameObject arrow;
    public GameObject sword;
    bool bAttack = false;
    bool bRun = false;
    bool bJump = false;
    bool bDead = false;
    bool bShoot = false;


    public AudioListener audiolistener = null;
    

    // Start is called before the first frame update
    void Start()
    {
        bow.SetActive(false);
        arrow.SetActive(false);
        sword.SetActive(false);
       

        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        audiolistener=GetComponent<AudioListener>();

        audioclip = Resources.Load(string.Format("Sound/Foot/{0}", "army")) as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * mouseSpeed, 0f, Space.World);

        }

        CharacterController_Slerp();
        //NavMesh_Control();
    }
    private void NavMesh_Control()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //agent.destination = hit.point;
                agent.SetDestination(hit.point);

            }
            else
            {

            }
            pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);
            animator.SetFloat("Speed", agent.velocity.magnitude);


        }

        if (agent.velocity.magnitude > 0.5f)
        {
            PlaySound(audioclip);
        }
        else
        {
            StopSound();
        }
    }



    private void FixedUpdate()
    {

        animator.SetFloat("Speed", agent.speed);
    }



    void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying) return;

        audioSource.PlayOneShot(clip); //,딜레이,


    }
    void StopSound()
    {
        audioSource.Stop();
    }
    private void CharacterController_Slerp()
    {

        //direction = new Vector3(0, 0, Input.GetAxis("Vertical"));
        direction = Input.GetAxis("Vertical") * this.transform.forward;
        print(direction);
        //direction = direction.normalized;


        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward
                , transform.forward
                , rotationSpeed * Time.deltaTime /
                Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
            print(forward);
        }
        else
        {


        }

   
        // 애니메이션 파라미터이름, 넘길 값;
        if (Input.GetAxis("Vertical") > 0)
        {

            if (pcController.velocity.magnitude > 0.5f)
            {
                PlaySound(audioclip);
            }
            else
            {
                StopSound();
            }
        }
        else
        {

            if(pcController.velocity.magnitude > 0.5f)
            {
                PlaySound(audioclip);
            }
            else
            {
                StopSound();
            }
        }

        animator.SetFloat("Speed", pcController.velocity.magnitude);
        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);


    }


    void onJump()
    {
        bJump = true;
    }
    void OffJump()
    {
        bJump = false;
    }

    void onAttack()
    {
        bAttack = true;
    }
    void onShoot()
    {
        bAttack = true;
        bShoot = true;
    }
    void offAttack()
    {
        print("22");
        bAttack = false;
        bShoot = false;
        bow.SetActive(false);
        arrow.SetActive(false);
        sword.SetActive(false);
    }
    void onArrow()
    {
        arrow.SetActive(true);//일단은 보이는 타이밍
        //나중엔 객체 생성
    }
}
