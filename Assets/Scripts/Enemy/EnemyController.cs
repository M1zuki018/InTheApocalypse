using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Õ“Ë‘Šè‚ªUŒ‚‚¾‚Á‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
        }
    }
}
