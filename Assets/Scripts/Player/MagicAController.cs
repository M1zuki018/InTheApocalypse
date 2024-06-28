using UnityEngine;

public class MagicAController : MonoBehaviour
{
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float _lifeTime = 3f;
    [SerializeField] int _damage = 10;

    GameObject _approachEnemy;

    void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (PlayerController._facingRight)
        {
            rb.velocity = Vector2.right * _speed; // 右方向に飛ばす
        }
        else if (PlayerController._facingLeft)
        {
            rb.velocity = Vector2.left * _speed; // 左方向に飛ばす
        }
        else
        {
            rb.velocity = Vector2.right * _speed;
        }

        // 生存期間が経過したら自分自身を破棄する
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemyHp))
        {
            if (!enemyHp._danger)
            {
                _approachEnemy = collision.gameObject;
                enemyHp._enemyHp = enemyHp._enemyHp - _damage;
            }
            else
            {
                enemyHp._breakCount = enemyHp._breakCount - _damage;
            }

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
