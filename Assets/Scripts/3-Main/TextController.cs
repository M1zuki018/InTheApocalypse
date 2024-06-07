using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject _textbox;
    public Text _text;
    public List<string> _textList;
    int _textcount;
    int _number = 5; //�e�L�X�g�̏I���

    //���Ԍo�ߊ֌W
    [SerializeField] float _interval = 5; //�Ԋu
    float _timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��̃e�L�X�g��\������
        _text.text = _textList[0];
        _textcount++;
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
