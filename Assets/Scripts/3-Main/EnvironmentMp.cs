using UnityEngine;
using UnityEngine.UI;
public class EnvironmentMp : MonoBehaviour
{
    //MP関係
    int _maxMP = 150;
    public int _mp = 150;
    public bool _mpNotEnough;
    public GameObject _notEnoughMpObj; //MPが足りない時に出すテキスト
    int _mpPlus = 0;
    public Slider _mpSlider;

    [SerializeField] Text _mpText;

    // Start is called before the first frame update
    void Start()
    {
        _mp = _maxMP;
        _notEnoughMpObj.SetActive(false);
        _mpSlider.value = _mp;

        _mpText.text = ("MP" + _mp + "/" + _maxMP);
    }

    // Update is called once per frame
    void Update()
    {
        if (_mp < _maxMP)
        {
            MagicPoint(); //MP自動回復
        }
        
        if (_mp < 0)
        {
            _mp = 0;
        }

        _mpSlider.value = (float)_mp;
        _mpText.text = ("MP" + _mp + "/" + _maxMP);
    }

    public void PlayerMagic() //魔法発動時の処理
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

    void MagicPoint() //MPの自動回復
    {
        _mpPlus++;

        if (_mpPlus % 300 == 0)
        {
            _mp++;
        }
    }
}
