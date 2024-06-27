using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public GameObject _textArea;　//親オブジェクトを登録
    [SerializeField] UnityEngine.UI.Text _text;

    //立ち絵関係
    [SerializeField] GameObject _charaObj;
    [SerializeField] Sprite[] _chara;
    [SerializeField] GameObject _skipText;
    SpriteRenderer _spriteRenderer;
    string _nameIndex;

    [Header("ストーリー・入力してね")]
    public List<string> _nameList;
    public List<string> _textList;

    int _namecount;
    public int _textcount;
    public int _number = 5; //テキストの終わり

    //時間経過関係
    [SerializeField] float _interval = 5; //間隔
    float _timeElapsed;

    void Awake()
    {
        _spriteRenderer = _charaObj.GetComponent<SpriteRenderer>();
        TextSet();
        _skipText.SetActive(false);
    }

    void Update()
    {
        if (_textArea.activeSelf)
        {
            _timeElapsed += Time.deltaTime;

            //最後のテキストが表示されたらスキップテキストを表示→スキップ処理
            if (_textcount == _number - 1)
            {
                _skipText.SetActive(true);
            }

            if (_timeElapsed >= _interval) //時間を計測して、
            {
                TextUpdate();
            }
        }
    }

    #region これ以上の変更なし
    void TextSet() //最初のテキストを読み込む
    {
        _text.text = (_nameList[0] + Regex.Unescape(_textList[0]));
        _nameIndex = _nameList[_namecount].ToString();
        SpriteChange();
    }

    public void TextUpdate() //テキストを更新する
    {
        //カウントを進める
        _namecount++;
        _textcount++;

        //カウントがナンバーに追いついたらテキストボックスを消す
        if (_textcount == _number + 1) 
        {
            _skipText.SetActive(false);
            _textArea.SetActive(false);
            return;
        }

        //表示を変更する
        _text.text = (_nameList[_namecount] + Regex.Unescape(_textList[_textcount]));
        _nameIndex = _nameList[_namecount].ToString();
        SpriteChange();

        //最後のテキストのスキップ処理
        if (_skipText.activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            _skipText.SetActive(false);
            _textArea.SetActive(false);
        }

        _timeElapsed = 0.0f;　//タイマーリセット
    }

    //画像登録
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
        _skipText.SetActive(false);
    }

    public void Set()
    {
        _textArea.SetActive(true);
    }

    #endregion

    #region Main1
    public void Event2Story()
    {
        _textcount = 5; //5から始める
        _namecount = 5;
        _number = 10; //10になったら終わる
        _textArea.SetActive(true); //オブジェクトを表示
    }

    public void Event5Story()
    {
        _textcount = 10;
        _namecount = 10;
        _number = 18;
        _textArea.SetActive(true);
    }

    #endregion

    #region Main2
    public void ZeppaStory()
    {
        _textArea.SetActive(true);
        _textcount = 0;
        _namecount = 0;
        _number = 4;
    }

    public void ZeppaStory1_2()
    {
        _textArea.SetActive(true);
        _textcount = 4;
        _namecount = 4;
        _number = 16;
    }

    public void Talk()
    {
        _textArea.SetActive(true);
        _textcount = 16;
        _namecount = 16;
        _number = 26;
    }
    #endregion

    #region Main3

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
    #endregion
}
