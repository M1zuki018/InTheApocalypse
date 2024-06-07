using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject _textbox;
    public Text _text;
    public List<string> _textList;
    int _textcount;
    int _number = 5; //テキストの終わり

    //時間経過関係
    [SerializeField] float _interval = 5; //間隔
    float _timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        //最初のテキストを表示する
        _text.text = _textList[0];
        _textcount++;
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= _interval)
        {
            if (_textcount == _number)　//カウントがナンバーに追いついたらテキストボックスを消す
            {
                _textbox.SetActive(false);
                return;
            }

            _text.text = _textList[_textcount];
            _textcount++;
            _timeElapsed = 0.0f;
        }
    }

    public void NextStory()
    {
        _textbox.SetActive(true);
        _textcount = 5;
        _number = 10;
    }
}
