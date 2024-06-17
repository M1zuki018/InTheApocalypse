using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class OpningTextController : MonoBehaviour
{
    [SerializeField] GameObject _textArea;　//親オブジェクトを登録
    [SerializeField] UnityEngine.UI.Text _text;


    [Header("ストーリー・入力してね")]
    public List<string> _textList;

    int _textcount;
    int _number = 7; //テキストの終わり

    //時間経過関係
    [SerializeField] float _interval = 5; //間隔
    float _timeElapsed;


    void Start()
    {
        Invoke("TextSet", 2);
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
    }

    void TextSet() //最初のテキストを読み込む
    {
        _text.text = (Regex.Unescape(_textList[0]));
        _textcount++;
    }

    void TextUpdate() //テキストを更新する
    {
        _text.text = (Regex.Unescape(_textList[_textcount]));
        _textcount++;
        _timeElapsed = 0.0f;
    }

    public void Enabled()
    {
        _textArea.SetActive(false);
    }

    public void Set()
    {
        _textArea.SetActive(true);
    }

}
