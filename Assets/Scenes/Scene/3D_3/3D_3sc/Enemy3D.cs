using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3D : MonoBehaviour
{

    public GameObject target;


    NavMeshAgent agent;

    Animator animator;

    public AudioClip audioclip = null;
    private AudioSource audioSource = null;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;

        animator.SetFloat("Speed", agent.speed);
        if (agent.velocity.magnitude > 0.5f)
        {
            PlaySound(audioclip);
        }
        else
        {
            StopSound();
        }

    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying) return;

        audioSource.Play(); //,µô·¹ÀÌ,


    }
    void StopSound()
    {
        audioSource.Stop();
    }
    private void OnDrawGizmos()
    {
        if (agent == null)
            return;

            //NavMeshPath path = agent.path;
            //Gizmos.color = Color.blue;
            //foreach (Vector3 corner in path.corners)
            //{
            //    Gizmos.DrawSphere(corner, 0.4f);

            //}
            //Gizmos.color = Color.red;
            //Vector3 pos = transform.position;
            //foreach (Vector3 corner in path.corners)
            //{
            //    Gizmos.DrawLine(pos, corner);
            //    pos = corner;
            //}
        
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
        //³ªÁß¿£ °´Ã¼ »ý¼º
    }
}
