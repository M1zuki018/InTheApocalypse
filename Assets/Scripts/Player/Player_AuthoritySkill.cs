using UnityEngine;

public class Player_AuthoritySkill : MonoBehaviour
{
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] Vector2 _skillBounds = Vector2.one;

    GameObject _seObj;
    Main1_SEController _seController;

    //�g�p�����@��΃A�C�R���������Ďg��

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
        //  hitInfo �̓L���X�g�̌��ʂ�Ԃ��̂Ŏ��s�����Ȃ�
        //  Null��Ԃ����炱���ň�x���@���f�[�V����
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // �͈͓��̑S�ẴI�u�W�F�N�g�ɑ΂��ē���̑���@�i�_���[�W�����j
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Debug.Log($"{hit.transform.name} is Hit");

                    // �G���ǂ��������ŕۏ�
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
