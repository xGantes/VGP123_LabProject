using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public float fireduration;

    Rigidbody2D rb;

    void Start()
    {
        if (fireduration <= 0)
        {
            fireduration = 1.0f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, fireduration);
    }

    private void Update()
    {
        /*if (rb.velocity.x != speed)
        {
            Destroy(gameObject);
        } */
    }
}
