using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnvironmentMp : MonoBehaviour
{
    //MP�֌W
    int _maxMP = 150;
    public int _mp = 150;
    public bool _mpNotEnough;
    public GameObject _notEnoughMpObj; //MP������Ȃ����ɏo���e�L�X�g
    int _mpPlus = 0;
    public Slider _mpSlider;

    // Start is called before the first frame update
    void Start()
    {
        _mp = _maxMP;
        _notEnoughMpObj.SetActive(false);
        _mpSlider.value = _mp;
    }

    // Update is called once per frame
    void Update()
    {
        MagicPoint(); //MP������
        _mpSlider.value = (float)_mp;
    }

    public void PlayerMagic() //���@�������̏���
    {
        Debug.Log(_mpNotEnough);
        if (_mpNotEnough == true)
        {
            _notEnoughMpObj.SetActive(true);
            Invoke("MpObjHidden", 3);
        }
    }

    void MpObjHidden()
    {
        _notEnoughMpObj.SetActive(false);
    }

    void MagicPoint() //MP�̎�����
    {
        _mpPlus++;

        if (_mpPlus % 200 == 0)
        {
            _mp++;
        }
    }
}
