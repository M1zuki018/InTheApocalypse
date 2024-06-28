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

    //�g�p�����@��΃A�C�R���������Ďg��

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
        //  hitInfo �̓L���X�g�̌��ʂ�Ԃ��̂Ŏ��s�����Ȃ�
        //  Null��Ԃ����炱���ň�x���@���f�[�V����
        {
            if (Input.GetKeyDown(KeyCode.Q) && AuthorityGage._gageCount >= 1)
            {
                AuthorityGage._gageCount--;
                // �͈͓��̑S�ẴI�u�W�F�N�g�ɑ΂��ē���̑���@�i�_���[�W�����j
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Debug.Log($"{hit.transform.name} is Hit");

                    // �G���ǂ��������ŕۏ�
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
