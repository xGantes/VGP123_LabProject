using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTurrent : MonoBehaviour
{
    //public float speed;
    //public float fireduration;

    //Rigidbody2D rb;

    //void Start()
    //{
    //    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    //    Destroy(gameObject, fireduration);
    //}

    public float time, damage;
    public GameObject effect;

    private void Start()
    {
        StartCoroutine(cd());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
    }
    IEnumerator cd()
    {
        yield return new WaitForSeconds(time);

        die();
    }

    void die()
    {
        Destroy(gameObject);
    }
}
