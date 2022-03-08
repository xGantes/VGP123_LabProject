using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    public Transform GroundCheckPos;
    public LayerMask WhatsGround;
    public Collider2D WallCollider;

    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //enemy speed
        isPatroling = true;
        if (Speed <= 0)
        {
            Speed = 30.0f;
        }
    }
    private void Update()
    {
        if (!isSquished && !isDying)
        {
            if (isPatroling)
            {
                rb.velocity = new Vector2(Speed * Time.fixedDeltaTime, rb.velocity.y);
                if (isFlipping || WallCollider.IsTouchingLayers(WhatsGround))
                {
                    Flips();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (isPatroling)
        {
            isFlipping = !Physics2D.OverlapCircle(GroundCheckPos.position, 0.2f, WhatsGround);
        }
    }
    void Flips()
    {
        isPatroling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        Speed *= -1;
        isPatroling = true;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        Debug.Log("Enemy took " + damage + " damage");
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            //sr.flipx = !sr.flipx;
        }
    }
    */

    public void Squished()
    {
        //animation

        //velocity after getting squished
        rb.velocity = Vector2.zero;
        //gameobject after getting squished
        Destroy(transform.parent.gameObject, 1f);
    }

    public override void Death()
    {
        base.Death();
        //animation no jutsu

        //velocity afterdeath
        rb.velocity = Vector2.zero;
        //afterdeath destroy object
        Destroy(transform.parent.gameObject, 1f);
    }
}
