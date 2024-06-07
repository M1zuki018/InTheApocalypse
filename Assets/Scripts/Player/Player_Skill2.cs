
using UnityEngine;

public class Player_Skill2 : MonoBehaviour
{
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] Vector2 _skillBounds = Vector2.one;

    public static float _skillCoolTime2 = 6000f;
    public static float _skillTimerCount2 = 6000f;

    private void Update()
    {
        // �o�ߎ��Ԃ̌v��
        _skillTimerCount2 += Time.deltaTime;

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
            if (Input.GetKeyDown(KeyCode.R) && _skillTimerCount2 >= _skillCoolTime2)
            {
                // �͈͓��̑S�ẴI�u�W�F�N�g�ɑ΂��ē���̑���@�i�_���[�W�����j
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Debug.Log($"{hit.transform.name} is Hit");

                    // �G���ǂ��������ŕۏ�
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

                // �S�ẴI�u�W�F�N�g�ɑ΂��鏈�����������ď��߂ă^�C�}�[�̏�����
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
