using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MecanimControl : MonoBehaviour
{
    public float runSpeed = 10.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;




    Animator animator;
    public GameObject bow;
    public GameObject arrow;
    public GameObject sword;
    bool bAttack = false;
    bool bRun = false;
    bool bJump = false;
    bool bDead = false;
    bool bShoot = false;




    // Start is called before the first frame update
    void Start()
    {

        bow.SetActive(false);
        arrow.SetActive(false);
        sword.SetActive(false);
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bDead) return;

        Input_Animation();
        CharacterController_Slerp();
        //if (Input.GetKeyDown(KeyCode.LeftControl) && !bAttack)
        //{
        //    bAttack = true;
        //    animator.SetBool("isAttack", bAttack);
        //    StartCoroutine("Attack_Routine");
        //}

    }

    //IEnumerator Attack_Routine()
    //{
    //    while (true)
    //    {

    //        yield return new WaitForSeconds(0);
    //        if (bAttack && animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.Jump"))
    //        {
    //            print("pass");
    //            if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime>= 0.9f)//애니메이션이 다 끝날시점 
    //            {
    //                print("1");
    //                bAttack = false;
    //                animator.SetBool("isAttack", bAttack);
    //                break;

    //            }
    //        }
    //    }
    //}

    private void Input_Animation()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            bRun = true;
            animator.SetBool("bRun", bRun);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && bRun)
        {
            bRun = false;
            animator.SetBool("bRun", bRun);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && bRun)
        {
            animator.SetTrigger("tSlide");
        }
        if (Input.GetKeyDown(KeyCode.Space) && !bJump)
        {

            animator.SetTrigger("tJump");
        }


        if (Input.GetKeyDown(KeyCode.Y))//죽음
        {

            animator.SetTrigger("tDead");
            bDead = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && !bAttack)//활공격
        {

            animator.SetTrigger("tArrow");

            bow.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.L) && !bAttack)//칼공격
        {

            animator.SetTrigger("tAttack");

            sword.SetActive(true);

        }

    }

    private void CharacterController_Slerp()
    {
        if (bRun)
        {
            runSpeed = 10f;
        }
        else
        {
            runSpeed = 5f;
        }
        if (bAttack &&!bShoot)
        {
            runSpeed = 1f;
        }
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

