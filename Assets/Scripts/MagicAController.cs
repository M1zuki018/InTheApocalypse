using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAController : MonoBehaviour
{
    /// <summary>�e����ԑ���</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>�e�̐������ԁi�b�j</summary>
    [SerializeField] float _lifeTime = 5f;

    GameObject _approachEnemy;

    void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (PlayerController._facingRight)
        {
            rb.velocity = Vector2.right * _speed; // �E�����ɔ�΂�
        }
        else if (PlayerController._facingLeft)
        {
            rb.velocity = Vector2.left * _speed; // �������ɔ�΂�
        }
        else
        {
            rb.velocity = Vector2.right * _speed;
        }
        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemyHp))
        {
            _approachEnemy = collision.gameObject;
            enemyHp._enemyHp = enemyHp._enemyHp - 30;

            if (enemyHp._enemyHp <= 0)
            {
                Destroy(_approachEnemy.gameObject);
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
