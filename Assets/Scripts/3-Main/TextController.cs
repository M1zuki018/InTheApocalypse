using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TextController : MonoBehaviour
{
    public GameObject _textbox;
    public UnityEngine.UI.Text _text;
    public List<string> _textList;
    public List<string> _nameList;
    int _textcount;
    int _namecount;
    int _number = 5; //�e�L�X�g�̏I���

    //���Ԍo�ߊ֌W
    [SerializeField] float _interval = 5; //�Ԋu
    float _timeElapsed;

    //�����G�֌W
    SpriteRenderer _spriteRenderer;
    public GameObject _charaObj;
    [SerializeField] Sprite[] _chara;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = _charaObj.GetComponent<SpriteRenderer>();

        _text.text = (_nameList[0] + Regex.Unescape(_textList[0]));
        _namecount++;
        _textcount++;
        //SpriteChange();
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= _interval)
        {
            if (_textcount == _number)�@//�J�E���g���i���o�[�ɒǂ�������e�L�X�g�{�b�N�X������
            {
                _textbox.SetActive(false);
                return;
            }

            _text.text = (_nameList[_namecount] + Regex.Unescape(_textList[_textcount]));
            _textcount++;
            _namecount++;
            _timeElapsed = 0.0f;
            //SpriteChange();
        }
    }

    /*
    void SpriteChange()
    {
        if (_nameList[_namecount] == "�՗t")
        {
            _spriteRenderer.sprite = _chara[0];
        }
        else if (_nameList[_namecount] == "����")
        {
            _spriteRenderer.sprite = _chara[1];
        }
        else if (_nameList[_namecount] == "�m")
        {
            _spriteRenderer.sprite= _chara[2];
        }
    }
    */

    public void Event2Story()
    {
        _textbox.SetActive(true);
        _textcount = 5;
        _namecount = 5;
        _number = 10;
    }

    public void Event5Story()
    {
        _textbox.SetActive(true);
        _textcount = 10;
        _namecount = 10;
        _number = 18;
    }
}
