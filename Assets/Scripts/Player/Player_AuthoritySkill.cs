using System.Collections;
using UnityEngine;

public class Player_AuthoritySkill : MonoBehaviour
{
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] Vector2 _skillBounds = Vector2.one;
    [SerializeField] GameObject _sprite;
    [SerializeField] GameObject _panel;

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

        RaycastHit2D[] hitInfo;
        hitInfo = Physics2D.BoxCastAll(transform.parent.position, _skillBounds, 0, Vector2.up, 100f, _enemyLayer, -10, 10);
        TaskOfInsideBounds(hitInfo);

        if (Input.GetKeyDown(KeyCode.Q) && AuthorityGage._gageCount >= 1)
        {
            StartCoroutine(Performance());
            _seController.AuthoritySkill();
        }
    }

    IEnumerator Performance()
    {
        _sprite.SetActive(true);
        _panel.SetActive(true);

        yield return new WaitForSeconds(1f);
    
        _sprite.SetActive(false);
        _panel.SetActive(false);
    }

    private static void TaskOfInsideBounds(RaycastHit2D[] hitInfo)
    {
        if (hitInfo is not null)  /* hitInfo != null */
        //  hitInfo はキャストの結果を返すので失敗したなら
        //  Nullを返すからここで一度ヴァリデーション
        {
            if (Input.GetKeyDown(KeyCode.Q) && AuthorityGage._gageCount >= 1)
            {
                AuthorityGage._gageCount--;
                // 範囲内の全てのオブジェクトに対して特定の操作　（ダメージ処理）
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Debug.Log($"{hit.transform.name} is Hit");

                    // 敵かどうかここで保障
                    if (hit.transform.TryGetComponent<EnemyController>(out var enemy))
                    {
                        if (!enemy._break)
                        {
                            enemy._enemyHp = enemy._enemyHp - 200;
                            Debug.Log($"{hit.transform.name} is Damaged");
                        }
                        else
                        {
                            enemy._breakCount = enemy._breakCount - 200;
                        }

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
