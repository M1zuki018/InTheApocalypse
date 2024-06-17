using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class OpningTextController : MonoBehaviour
{
    [SerializeField] GameObject _textArea;�@//�e�I�u�W�F�N�g��o�^
    [SerializeField] UnityEngine.UI.Text _text;


    [Header("�X�g�[���[�E���͂��Ă�")]
    public List<string> _textList;

    int _textcount;
    int _number = 7; //�e�L�X�g�̏I���

    //���Ԍo�ߊ֌W
    [SerializeField] float _interval = 5; //�Ԋu
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
            if (_textcount == _number)�@//�J�E���g���i���o�[�ɒǂ�������e�L�X�g�{�b�N�X������
            {
                _textArea.SetActive(false);
                return;
            }

            TextUpdate();

        }
    }

    void TextSet() //�ŏ��̃e�L�X�g��ǂݍ���
    {
        _text.text = (Regex.Unescape(_textList[0]));
        _textcount++;
    }

    void TextUpdate() //�e�L�X�g���X�V����
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
