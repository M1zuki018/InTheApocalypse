using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmation : MonoBehaviour
{
    //�@�{�^������������Ґ����[�h�ɓ���
    //�A�Ґ����[�h�ł́A�J�[�\��������s��
    //�B�I���Ŏ����グ��AA/D�ō��E�ړ��A�m��

    public GameObject _cursor;

    // Start is called before the first frame update
    void Start()
    {
        _cursor.SetActive(false);
        _cursor.transform.position = new Vector2 (-3.5f , 0.0f);
    }

    void Update()
    {
        CursorController();
    }

    public void FormationChange()
    {
        _cursor.SetActive(true); //�J�[�\���\��
    }

    void CursorController()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            _cursor.transform.position = new Vector2(-1.3f, 0.0f);
        }
    }
}
