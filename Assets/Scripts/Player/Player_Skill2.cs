using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill2 : MonoBehaviour
{
    GameObject _approachEnemy;

    public static int _skillCount2 = 6000;
    public static int _skillCoolTime2 = 6000;

    private void Update()
    {
        _skillCount2++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemyHp))
        {
            _approachEnemy = collision.gameObject;

            if (Input.GetKeyDown(KeyCode.R) && _skillCount2 >= _skillCoolTime2)
            {
                _skillCount2 = 0;
                enemyHp._enemyHp = enemyHp._enemyHp - 60;
            }

            if (enemyHp._enemyHp <= 0)
            {
                Destroy(_approachEnemy.gameObject);
            }
        }

    }
}