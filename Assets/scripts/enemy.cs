using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    bool isGrounded;

    Animator m_Animator;

    public float speed = 10f;
    public float regular;
    public float stoppingDist = 2f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        regular = speed;
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float ex = transform.position.x;
        float px = player.transform.position.x;
        float dist = ex - px;
        Vector2 velocity = rb.velocity;
        
        


        if (ex < px)
        {

            Helper.DoFaceLeft(gameObject, false);
        }
        else
        {

            Helper.DoFaceLeft(gameObject, true);

        }


        // move enemy towards player

        velocity.x = 0;
        if( dist < -2 )
        {
            velocity.x = 2;
            m_Animator.SetBool("IsMoving", true);
        }
        else
        {
            m_Animator.SetTrigger("IsAttacking");
            m_Animator.SetBool("IsMoving", false);
        }


        if( dist > stoppingDist )
        {
            velocity.x = -stoppingDist;
        }


        rb.velocity = velocity;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    


    /* Helper.followPlayer();
      if(player > 2)
         {

         }

     if(player > -2)
         {

         }*/



}