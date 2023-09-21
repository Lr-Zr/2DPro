using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class IKTest : MonoBehaviour
{

    [Range(0, 1)]
    public float posWeight = 1;

    [Range(0, 1)]
    public float rotWeight = 1;


    public Transform rightHandFollowObj;

    protected Animator animator;

    private int selectWeight = 1;

    //È¸Àü 
    [Range(0, 359)]
    public float xRot = 0.0f;

    [Range(0, 359)]
    public float yRot = 0.0f;

    [Range(0, 359)]
    public float zRot = 0.0f;





    ///-->>>>>>>>>>>>1
    bool wall;
    bool hold;
    bool onGround;
    public Transform lhObj;
    public Transform rhObj;
    public Transform llObj;
    public Transform rlObj;

    int dirrh = 1;
    int dirlh = 1;
    int dirrl = 1;
    int dirll = 1;


    public float runSpeed = 4.0f;
    public float mouseSpeed = 5f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;






    // Start is called before the first frame update
    void Start()
    {
        hold = false;
        wall = false;

        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController_Slerp();
        if (Input.GetKeyDown(KeyCode.Space) && wall)
        {
            hold = true;
            print("hold" + hold);
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            hold = false;
            if (!onGround)
                hold = true;
            print("hold" + hold);
        }
        if (hold)
            poschange();


        if (wall && hold)
        {

        }
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    selectWeight = 1;//position
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    selectWeight = 2;//rotation
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    selectWeight = 3;//
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    selectWeight = 4;//
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    selectWeight = 5;//
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    selectWeight = 6;//
        //}


    }


    private void CharacterController_Slerp()
    {
        if (hold)
        {


            Vector3 pos = transform.position;
            if (Input.GetAxis("Vertical") < 0 && onGround)
                return;
            else
                pos.y += Input.GetAxis("Vertical") * 3 * Time.deltaTime;

            this.transform.position = pos;

            return;
        }
        //direction = new Vector3(0, 0, Input.GetAxis("Vertical"));
        direction = Input.GetAxis("Vertical") * this.transform.forward;

        //direction = direction.normalized;


        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward
                , transform.forward
                , rotationSpeed * Time.deltaTime /
                Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);

        }
        else
        {


        }



        animator.SetFloat("Speed", pcController.velocity.magnitude);
        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);


    }


    private void poschange()
    {
        Vector3 opos = this.transform.position;
        Vector3 rhpos = rhObj.localPosition;
        Vector3 lhpos = lhObj.localPosition;
        Vector3 rlpos = rlObj.localPosition;
        Vector3 llpos = llObj.localPosition;
      
        
        rhpos.y -= dirrh * 2f * Time.deltaTime* Input.GetAxis("Vertical");
        lhpos.y -= dirlh * 2f * Time.deltaTime* Input.GetAxis("Vertical");
        rlpos.y -= dirrl * 2f * Time.deltaTime* Input.GetAxis("Vertical");
        llpos.y -= dirll * 2f * Time.deltaTime * Input.GetAxis("Vertical");

        if (rhpos.y < 2.0f)
        {
            dirrh *= -1;
            rhpos.y = 2.0f;
        }
        if (rhpos.y > 2.9f)
        {
            dirrh *= -1;
            rhpos.y = 2.9f;
        }

        if (lhpos.y < 2.1f)
        {
            dirlh *= -1;
            lhpos.y = 2.1f;
        }
        if (lhpos.y > 2.6f)
        {
            dirlh *= -1;
            lhpos.y = 2.6f;
        }

        if (rlpos.y < 0.3f)
        {
            dirrl *= -1;
            rlpos.y = 0.3f;
        }
        if (rlpos.y > 1.5f)
        {
            dirrl *= -1;
            rlpos.y = 1.5f;
        }


        if (llpos.y < 0.3f)
        {
            dirll *= -1;
            llpos.y = 0.3f;
        }
        if (llpos.y > 1.5f)
        {
            dirll *= -1;
            llpos.y = 1.5f;
        }





        rhObj.localPosition = rhpos;
        lhObj.localPosition = lhpos;
        rlObj.localPosition = rlpos;
        llObj.localPosition = llpos;

    }

    private void OnAnimatorIK(int layerIndex)
    {
        
        if (animator != null)
        {
            if (rlObj != null && llObj != null && rhObj != null && lhObj != null)
            {
                //switch (selectWeight)
                //{
                //    case 1: SetPositionWeight(); break;
                //    case 2: SetRotationWeight(); break;
                //    case 3: SetEachWeight(); break;
                //    case 4: SetRotationAngle(); break;
                //    case 5: SetLookAtObj(); break;
                //    case 6: SetLegWeight(); break;


                //}
                print("animatorik111");
                if (hold)
                {
                    print("animatorik");
                    SetPostionAll();

                }
            }
        }

    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            print("can space");
            wall = true;
            print(wall);
        }
        if (collision.collider.tag == "Ground")
        {

            onGround = true;
            print("Ground " + onGround);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            wall = false;
            print(wall);
        }
        if (collision.collider.tag == "Ground")
        {

            onGround = false;
            print("Ground " + onGround);
        }

    }




    private void SetPostionAll()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);

        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0.0f);


        animator.SetIKPosition(AvatarIKGoal.RightHand, rhObj.position);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, lhObj.position);
        animator.SetIKPosition(AvatarIKGoal.RightFoot, rlObj.position);
        animator.SetIKPosition(AvatarIKGoal.LeftFoot, llObj.position);

        Quaternion rhrotataion = Quaternion.LookRotation(rhObj.position - transform.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, rhrotataion);
        Quaternion lhrotataion = Quaternion.LookRotation(lhObj.position - transform.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, lhrotataion);
        Quaternion rlrotataion = Quaternion.LookRotation(rlObj.position - transform.position);
        animator.SetIKRotation(AvatarIKGoal.RightFoot, rlrotataion);
        Quaternion llrotataion = Quaternion.LookRotation(llObj.position - transform.position);
        animator.SetIKRotation(AvatarIKGoal.LeftFoot, llrotataion);



    }








    private void SetPositionWeight()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, posWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);

        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandFollowObj.position);

        Quaternion handRotation = Quaternion.LookRotation(rightHandFollowObj.position - transform.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, handRotation);

    }


    private void SetRotationWeight()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rotWeight);

        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandFollowObj.position);

        Quaternion handRotation = Quaternion.LookRotation(rightHandFollowObj.position - transform.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, handRotation);
    }


    private void SetEachWeight()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, posWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rotWeight);

        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandFollowObj.position);

        Quaternion handRotation = Quaternion.LookRotation(rightHandFollowObj.position - transform.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, handRotation);
    }

    private void SetRotationAngle()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, posWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rotWeight);

        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandFollowObj.position);

        Quaternion handRotation = Quaternion.Euler(xRot, yRot, zRot);
        animator.SetIKRotation(AvatarIKGoal.RightHand, handRotation);
    }


    private void SetLookAtObj()
    {
        animator.SetLookAtWeight(1.0f);
        animator.SetLookAtPosition(rightHandFollowObj.position);
    }
    private void SetLegWeight()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, posWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rotWeight);

        animator.SetIKPosition(AvatarIKGoal.RightFoot, rightHandFollowObj.position);

        Quaternion handRotation = Quaternion.Euler(xRot, yRot, zRot);
        animator.SetIKRotation(AvatarIKGoal.RightFoot, handRotation);
    }
}
