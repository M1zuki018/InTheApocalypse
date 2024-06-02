using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill1 : MonoBehaviour
{
    GameObject _player;
    Rigidbody2D _playerRb;
    GameObject _approachEnemy;
    public static int _skillCount1 = 5000;
    public static int _skillCoolTime1 = 5000;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerRb = _player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _skillCount1++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemyHp))
        {
            _approachEnemy = collision.gameObject;

            if (Input.GetKeyDown(KeyCode.E)&& _skillCount1 >= _skillCoolTime1)
            {
                _skillCount1 = 0;
                _playerRb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                enemyHp._enemyHp = enemyHp._enemyHp - 80;
            }

            if (enemyHp._enemyHp <= 0)
            {
                Destroy(_approachEnemy.gameObject);
            }
        }
    }
}
