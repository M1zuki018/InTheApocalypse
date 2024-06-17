using UnityEngine;

public class Player_AuthoritySkill : MonoBehaviour
{
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] Vector2 _skillBounds = Vector2.one;

    GameObject _seObj;
    Main1_SEController _seController;

    //使用条件　宝石アイコンを消して使う

    private void Start()
    {
        _seObj = GameObject.Find("SE");
        _seController = _seObj.GetComponent<Main1_SEController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _seController.AuthoritySkill();
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // 範囲内の全てのオブジェクトに対して特定の操作　（ダメージ処理）
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Debug.Log($"{hit.transform.name} is Hit");

                    // 敵かどうかここで保障
                    if (hit.transform.TryGetComponent<EnemyController>(out var enemy))
                    {
                        enemy._enemyHp = enemy._enemyHp - 200;
                        Debug.Log($"{hit.transform.name} is Damaged");

                        if (enemy._enemyHp <= 0)
                        {
                            Destroy(hit.collider.gameObject);
                        }
                    }

                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _skillBounds);
    }
}
