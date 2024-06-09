using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMenu : MonoBehaviour
{
    //キャラクターボタンを押したときにキャラクターパネルを開く
    //キャラクターボタンにアタッチして、対応するキャラパネルをアサインする

    public GameObject _CharaMenu;

    // Start is called before the first frame update
    void Start()
    {
        _CharaMenu.SetActive(false);   
    }

    public void CharaPanelOpen()
    {
        _CharaMenu.SetActive(true);
    }

    public void CharaPanelClose()
    {
        _CharaMenu.SetActive(false);
    }
}
