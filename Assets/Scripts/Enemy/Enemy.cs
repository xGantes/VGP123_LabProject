using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator animator;

    //floats
    public float Speed;

    //bools
    public bool isAttacking;
    public bool isPatroling;
    public bool isFlipping;
    public bool isSquished;
    public bool isDying;
    private bool verbose;

    protected int _enemHealth;
    protected int maxHealth;

    public int enemyHealth
    {
        get
        {
            return _enemHealth;
        }
        set
        {
            _enemHealth = value;
            if (enemyHealth > maxHealth)
            {
                enemyHealth = maxHealth;
            }
            else if (enemyHealth <= 0)
            {
                //Death();
            }
        }
    }

    public virtual void Death()
    {
        if (verbose)
        {
            Debug.Log("Death is overriden and also been implemented.");
        }
    }

    public virtual void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    public virtual void DestroyObject()
    {
        Destroy(gameObject);
    }

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //enemy health
        if (maxHealth <= 0)
        {
            maxHealth = 10;
        }
        enemyHealth = maxHealth;
    }
    private void Update()
    {
        Enemy_Animation();
    }
    private void Enemy_Animation()
    {

    }
}
