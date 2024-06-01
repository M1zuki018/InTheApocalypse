using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    GameObject _approachEnemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemyHp))
        {
            _approachEnemy = collision.gameObject;

            if (Input.GetButtonDown("Fire1"))
            {
                enemyHp._enemyHp = enemyHp._enemyHp - 30;
            }

            if (enemyHp._enemyHp <= 0)
            {
                Destroy(_approachEnemy.gameObject);
            }
        }
    }
}
