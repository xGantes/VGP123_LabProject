using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControls))]
public class PlayerFire : MonoBehaviour
{
    private SpriteRenderer sr;
    Animator animator;

    public Transform spawnLeft;
    public Transform spawnRight;

    public float projectileSpeed;
    public Projectiles projectilePrefabs;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if(projectileSpeed <= 0)
        {
            projectileSpeed = 5.0f;
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("isFiring");
        }
    }
    public void FireFacing()
    {
        if(sr.flipX)
        {
            Projectiles temp = Instantiate(projectilePrefabs, spawnLeft.position, spawnLeft.rotation);
            temp.speed = -projectileSpeed;
        }
        else
        {
            Projectiles temp = Instantiate(projectilePrefabs, spawnRight.position, spawnRight.rotation);
            temp.speed = projectileSpeed;
        }
    }
}
