using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter OnTriggerEnter2D."); // �֐����Ăяo���ꂽ�� Console �Ƀ��O���o�͂���

        // �Փˑ��肪�U���������玩�����g��j������
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
        }
    }
}
