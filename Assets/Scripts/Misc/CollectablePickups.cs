using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickups : MonoBehaviour
{
    enum CollectibleType
    {
        POWERUP,
        SCORE,
        LIFE
    }
    [SerializeField] CollectibleType collectables;
    private Rigidbody2D rb;
    public int gamescore;

    public void Start()
    {
        if(collectables == CollectibleType.LIFE)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(4, rb.velocity.y);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerControls playerCon = collision.gameObject.GetComponent<PlayerControls>();
            switch(collectables)
            {
                case CollectibleType.POWERUP:
                    playerCon.PowerJumpForce();
                    playerCon.score += gamescore;
                    break;
                case CollectibleType.LIFE:
                    playerCon.lives++;
                    playerCon.score += gamescore;
                    break;
                case CollectibleType.SCORE:
                    playerCon.score += gamescore;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
