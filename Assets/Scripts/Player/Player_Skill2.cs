
using Unity.VisualScripting;
using UnityEngine;

public class Player_Skill2 : MonoBehaviour
{
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] Vector2 _skillBounds = Vector2.one;

    public static float _skillCoolTime2 = 45f;
    public static float _skillTimerCount2 = 45f;

    GameObject _seObj;
    Main1_SEController _seController;

    private void Start()
    {
        _seObj = GameObject.Find("SE");
        _seController = _seObj.GetComponent<Main1_SEController>();

    }
    private void Update()
    {
       
        // 経過時間の計測
        _skillTimerCount2 += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && _skillTimerCount2 >= _skillCoolTime2)
        {
            _seController.Skill2();
        }

        RaycastHit2D[] hitInfo;
        hitInfo = Physics2D.BoxCastAll(transform.parent.position, _skillBounds, 0, Vector2.up, 100f, _enemyLayer, -10, 10);
        TaskOfInsideBounds(hitInfo);
    }

   


    private static void TaskOfInsideBounds(RaycastHit2D[] hitInfo)
    {
        if (hitInfo is not null)  /* hitInfo != null */
        //  hitInfo はキャストの結果を返すので失敗したなら
        //  Nullを返すからここで一度ヴァリデーション
        {
            if (Input.GetKeyDown(KeyCode.R) && _skillTimerCount2 >= _skillCoolTime2)
            {

                // 範囲内の全てのオブジェクトに対して特定の操作　（ダメージ処理）
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Debug.Log($"{hit.transform.name} is Hit");

                    // 敵かどうかここで保障
                    if (hit.transform.TryGetComponent<EnemyController>(out var enemy))
                    {
                        enemy._enemyHp = enemy._enemyHp - 60;
                        Debug.Log($"{hit.transform.name} is Damaged");

                        if (enemy._enemyHp <= 0)
                        {
                            Destroy(hit.collider.gameObject);
                        }
                    }

                }

                // 全てのオブジェクトに対する処理が完了して初めてタイマーの初期化
                _skillTimerCount2 = 0;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _skillBounds);
    }
}
