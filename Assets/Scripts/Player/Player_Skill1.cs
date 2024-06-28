using UnityEngine;

public class Player_Skill1 : MonoBehaviour
{

    GameObject _player;
    Rigidbody2D _playerRb;

    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] Vector2 _skillBounds = Vector2.one;

    public static float _skillCoolTime1 = 10f;
    public static float _skillTimerCount1 = 10f;

    [SerializeField] int _charge = 15; //突進時加える力

    GameObject _seObj;
    Main1_SEController _seController;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _seObj = GameObject.Find("SE");
        _seController = _seObj.GetComponent<Main1_SEController>();
    }

    private void Update()
    {
        // 経過時間の計測
        _skillTimerCount1 += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && _skillTimerCount1 >= _skillCoolTime1)
        {
            
            _seController.Skill1();
            if (PlayerController._facingRight)
            {
                _playerRb.AddForce(Vector2.right * _charge, ForceMode2D.Impulse);
            }
            else if (PlayerController._facingLeft)
            {
                _playerRb.AddForce(Vector2.left * _charge, ForceMode2D.Impulse);
            }
        }

        RaycastHit2D[] hitInfo;
        hitInfo = Physics2D.BoxCastAll(transform.parent.position, _skillBounds, 0, Vector2.up, 1000f, _enemyLayer, -10, 10);
        TaskOfInsideBounds(hitInfo);

    }

    private static void TaskOfInsideBounds(RaycastHit2D[] hitInfo)
    {
        if (hitInfo is not null)  /* hitInfo != null */
        //  hitInfo はキャストの結果を返すので失敗したなら
        //  Nullを返すからここで一度ヴァリデーション
        {
            if (Input.GetKeyDown(KeyCode.E) && _skillTimerCount1 >= _skillCoolTime1)
            {
                // 範囲内の全てのオブジェクトに対して特定の操作　（ダメージ処理）
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Debug.Log($"{hit.transform.name} is Hit");

                    // 敵かどうかここで保障
                    if (hit.transform.TryGetComponent<EnemyController>(out var enemy))
                    {
                        if (!enemy._danger)
                        {
                            enemy._enemyHp = enemy._enemyHp - 60;
                            Debug.Log($"{hit.transform.name} is Damaged");
                        }
                        else
                        {
                            enemy._breakCount = enemy._breakCount - 60;
                        }

                        if (enemy._enemyHp <= 0)
                        {
                            Destroy(hit.collider.gameObject);
                        }
                    }

                }

                // 全てのオブジェクトに対する処理が完了して初めてタイマーの初期化
                _skillTimerCount1 = 0;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _skillBounds);
    }

}
