using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed, range, timetoShoot, shootSpeed;
    private float distoPlayer;

    public bool isPatrolling, isCasting;
    private bool isFlipping;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public Transform player, shotPos;
    public LayerMask whatsGround;
    public Collider2D bodyCollider;
    public GameObject cast;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isPatrolling = true;
        isCasting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPatrolling)
        {
            Patrols();
        }
        distoPlayer = Vector2.Distance(transform.position, player.position);

        if(distoPlayer <= range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flips();
            }
            isPatrolling = false;
            rb.velocity = Vector2.zero;

            if(isCasting)
            StartCoroutine(Shoot());
        }
    }
    private void FixedUpdate()
    {
        if(isPatrolling)
        {
            isFlipping = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, whatsGround);
        }
    }
    void Patrols()
    {
        if(isFlipping || bodyCollider.IsTouchingLayers(whatsGround))
        {
            Flips();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flips()
    {
        isPatrolling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        isPatrolling = true;
    }

    IEnumerator Shoot()
    {
        isCasting = false;
        yield return new WaitForSeconds(timetoShoot);
        GameObject newCast = Instantiate(cast, shotPos.position, Quaternion.identity);

        newCast.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * speed * Time.fixedDeltaTime, 0f); ;
        isCasting = true;
    }
}
