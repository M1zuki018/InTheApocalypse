using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] Vector2 _skillBounds = Vector2.one;

    GameObject _seObj;
    Main1_SEController _seController;

    private void Start()
    {
        _seObj = GameObject.Find("SE");
        _seController = _seObj.GetComponent<Main1_SEController>();
    }

    private void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(transform.parent.position, _skillBounds, 0, Vector2.right, 1f, _enemyLayer, -10, 10);
        TaskOfInsideBounds(hit);

        if (Input.GetButtonDown("Fire1"))
        {
            _seController.Attack();
        }
    }

    private static void TaskOfInsideBounds(RaycastHit2D hit)
    {
        if (hit == false)
        {
            //Debug.Log("ãﬂÇ≠Ç…ëŒè€Ç™ë∂ç›ÇµÇ‹ÇπÇÒ");
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            // ìGÇ©Ç«Ç§Ç©Ç±Ç±Ç≈ï€è·
            if (hit.transform.TryGetComponent<EnemyController>(out var enemy))
            {
                enemy._enemyHp = enemy._enemyHp - 10;
                Debug.Log($"{hit.transform.name} is Damaged");

                if (enemy._enemyHp <= 0)
                {
                    Destroy(hit.collider.gameObject);
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
