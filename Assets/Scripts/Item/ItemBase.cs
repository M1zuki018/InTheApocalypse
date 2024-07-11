using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Activate();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // �����Ȃ����Ɉړ�����
            this.transform.position = Camera.main.transform.position;
            // �R���C�_�[�𖳌��ɂ���
            GetComponent<Collider2D>().enabled = false;
            // �v���C���[�ɃA�C�e����n��
            collision.gameObject.GetComponent<PlayerItem>().GetItem(this);
        }
    }
}
