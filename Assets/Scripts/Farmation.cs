using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmation : MonoBehaviour
{
    //①ボタンを押したら編成モードに入る
    //②編成モードでは、カーソル操作を行う
    //③選択で持ち上げる、A/Dで左右移動、確定

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
        _cursor.SetActive(true); //カーソル表示
    }

    void CursorController()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            _cursor.transform.position = new Vector2(-1.3f, 0.0f);
        }
    }
}
