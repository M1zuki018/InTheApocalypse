﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public GameObject _textArea;　//親オブジェクトを登録
    [SerializeField] UnityEngine.UI.Text _text;

    //立ち絵関係
    [SerializeField] GameObject _charaObj;
    [SerializeField] Sprite[] _chara;
    SpriteRenderer _spriteRenderer;
    string _nameIndex;

    [Header("ストーリー・入力してね")]
    public List<string> _nameList;
    public List<string> _textList;

    int _namecount;
    public int _textcount;
    int _number = 5; //テキストの終わり

    //時間経過関係
    [SerializeField] float _interval = 5; //間隔
    float _timeElapsed;

    void Start()
    {
        _spriteRenderer = _charaObj.GetComponent<SpriteRenderer>();
        TextSet();
    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= _interval)
        {
            if (_textcount == _number)　//カウントがナンバーに追いついたらテキストボックスを消す
            {
                _textArea.SetActive(false);
                return;
            }

            TextUpdate();

        }

        if (Input.GetKeyDown(KeyCode.Return) && _textcount <= _number -1)
        {
            TextUpdate();
        }
    }

    #region これ以上の変更なし
    void TextSet() //最初のテキストを読み込む
    {
        _text.text = (_nameList[0] + Regex.Unescape(_textList[0]));
        _nameIndex = _nameList[_namecount].ToString();
        SpriteChange();
        _namecount++;
        _textcount++;
    }

    void TextUpdate() //テキストを更新する
    {
        _text.text = (_nameList[_namecount] + Regex.Unescape(_textList[_textcount]));
        _nameIndex = _nameList[_namecount].ToString();
        SpriteChange();
        _textcount++;
        _namecount++;
        _timeElapsed = 0.0f;
    }

    void SpriteChange()
    {
        if (_nameIndex == "琴葉")
        {
            _spriteRenderer.sprite = _chara[0];
        }
        else if (_nameIndex == "響希")
        {
            _spriteRenderer.sprite = _chara[1];
        }
        else if (_nameIndex == "仁")
        {
            _spriteRenderer.sprite = _chara[2];
        }
    }
    public void Enabled()
    {
        _textArea.SetActive(false);
    }

    public void Set()
    {
        _textArea.SetActive(true);
    }

    #endregion

    #region Main1
    public void Event2Story()
    {
        _textArea.SetActive(true); //オブジェクトを表示
        _textcount = 5; //5から始める
        _namecount = 5;
        _number = 10; //10になったら終わる
    }

    public void Event5Story()
    {
        _textArea.SetActive(true);
        _textcount = 10;
        _namecount = 10;
        _number = 18;
    }

    #endregion

    public void ZeppaStory()
    {
        _textArea.SetActive(true);
        _textcount = 0;
        _namecount = 0;
        _number = 5;
    }

    public void ZeppaStory1_2()
    {
        _textArea.SetActive(true);
        _textcount = 5;
        _namecount = 5;
        _number = 16;
    }

    public void Talk()
    {
        _textArea.SetActive(true);
        _textcount = 16;
        _namecount = 16;
        _number = 27;
    }

    public void Main3()
    {
        _textArea.SetActive(true);
        _textcount = 0;
        _namecount = 0;
        _number = 10;
    }

    public void Main3End()
    {
        _textArea.SetActive(true);
        _textcount = 10;
        _namecount = 10;
        _number = 20;
    }

}
