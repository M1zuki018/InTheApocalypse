using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突相手が攻撃だったら自分自身を破棄する
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
            PlayerController._mp = PlayerController._mp + 10;
        }
    }
}
