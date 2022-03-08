using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float GroundCheckRadius;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask WhatIsGround;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    Animator animator;

    //private bool isFacing = true;
    //private Vector3 Velocity = Vector3.zero;

    public bool verbose = false;
    public bool isGrounded;
    private bool isCoRoutineRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if(Speed <= 0)
        {
            Speed = 4.0f;
            if (verbose)
                Debug.Log("Default changed to 5");
        }
        if(JumpForce <= 0)
        {
            JumpForce = 350f;
            if (verbose)
                Debug.Log("Default changed to 400f");
        }
        if (GroundCheckRadius <= 0)
        {
            GroundCheckRadius = 0.04f;
            if (verbose)
                Debug.Log("Default changed to 0.04f");
        }
        if(!GroundCheck)
        {
            GroundCheck = transform.GetChild(0);
            if(verbose)
            {
                if (GroundCheck.name == "GroundCheck")
                    Debug.Log("Ground Check Found");
                else
                    Debug.Log("Ground no found");
            }
        }
    }
    private void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * JumpForce);
        }

        AnimatorClipInfo[] currentClip = animator.GetCurrentAnimatorClipInfo(0);
        if(currentClip[0].clip.name != "isFiring")
        {
            Vector2 dirMove = new Vector2(horizontalMove * Speed, 
            rb.velocity.y);
            rb.velocity = dirMove;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("isGrounded", isGrounded);
        /*
        if (horizontalMove > 0 && !isFacing)
        {
            Flip();
        }
        else if (horizontalMove < 0 && isFacing)
        {
            Flip();
        } */

        if(horizontalMove > 0 && sr.flipX)
        {
            sr.flipX = !sr.flipX;
        }
        else if (horizontalMove < 0 && !sr.flipX)
        {
            sr.flipX = !sr.flipX;
        }
    }
    /*private void Flip()
    {
        isFacing = !isFacing;
        transform.Rotate(0f, 180f, 0f);
    } */

    public void PowerJumpForce()
    {
        if(!isCoRoutineRunning)
        {
            StartCoroutine("JumpForceChanger");
        }
        else
        {
            StopCoroutine("JumpForceChanger");
            JumpForce /= 1.5f;
            StartCoroutine("JumpForceChanger");
        }


    }
    IEnumerator JumpForceChanger()
    {
        isCoRoutineRunning = true;
        JumpForce *= 1.5f;

        yield return new WaitForSeconds(5.0f);

        JumpForce /= 1.5f;
        isCoRoutineRunning = false;
    }
}
