using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CrosshairController : MonoBehaviour
{

    void Start()
    {
        // �}�E�X�J�[�\��������
        //Cursor.visible = false;
    }

    void Update()
    {
        if (PlayerController._magicMode)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;    // Z ���W���J�����Ɠ����ɂȂ��Ă���̂ŁA���Z�b�g����
            this.transform.position = mousePosition;
        }
    }
}
