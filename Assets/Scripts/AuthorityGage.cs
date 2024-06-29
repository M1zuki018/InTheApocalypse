using UnityEngine;

public class AuthorityGage : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] _gage;
    public static int _gageCount = 0;

    [SerializeField] int _countUpCount = 20;
    int _push = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gage[0].color = new Color(0.13f, 0.13f, 0.13f, 1);
        _gage[1].color = new Color(0.13f, 0.13f, 0.13f, 1);
        _gage[2].color = new Color(0.13f, 0.13f, 0.13f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
        CountUp();
        //Debug.Log(_push);
    }

    void ColorChange()
    {
        if (_gageCount == 0)
        {
            _gage[0].color = new Color(0.13f, 0.13f, 0.13f, 1);
            _gage[1].color = new Color(0.13f, 0.13f, 0.13f, 1);
            _gage[2].color = new Color(0.13f, 0.13f, 0.13f, 1);
        }
        else if (_gageCount == 1)
        {
            _gage[0].color = new Color(1, 0.85f, 0.79f, 1);
            _gage[1].color = new Color(0.13f, 0.13f, 0.13f, 1);
            _gage[2].color = new Color(0.13f, 0.13f, 0.13f, 1);
        }
        else if (_gageCount == 2)
        {
            _gage[0].color = new Color(1, 0.85f, 0.79f, 1);
            _gage[1].color = new Color(1, 0.85f, 0.79f, 1);
            _gage[2].color = new Color(0.13f, 0.13f, 0.13f, 1);
        }
        else if (_gageCount == 3)
        {
            _gage[0].color = new Color(1, 0.85f, 0.79f, 1);
            _gage[1].color = new Color(1, 0.85f, 0.79f, 1);
            _gage[2].color = new Color(1, 0.85f, 0.79f, 1);
        }
    }

    void CountUp()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            _push++;
        }

        if (_push >= _countUpCount)
        {
            _gageCount++;
            _push = 0;
        }
    }
}
