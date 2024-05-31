using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAController : MonoBehaviour
{
    /// <summary>’e‚ª”ò‚Ô‘¬‚³</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>’e‚Ì¶‘¶ŠúŠÔi•bj</summary>
    [SerializeField] float _lifeTime = 5f;

    float horizontal;

    void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (PlayerController._facingRight)
        {
            rb.velocity = Vector2.right * _speed; // ‰E•ûŒü‚É”ò‚Î‚·
        }
        else if (PlayerController._facingLeft)
        {
            rb.velocity = Vector2.left * _speed; // ¶•ûŒü‚É”ò‚Î‚·
        }
        else
        {
            rb.velocity = Vector2.right * _speed;
        }
        // ¶‘¶ŠúŠÔ‚ªŒo‰ß‚µ‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
