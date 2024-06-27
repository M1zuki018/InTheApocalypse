using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthorityGage : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] _gage;
    public static int _gageCount = 0;

    [SerializeField] int _countUpCount = 20;
    int _push = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gage[0].color = new Color(35, 35, 35, 255);
        _gage[1].color = new Color(35, 35, 35, 255);
        _gage[2].color = new Color(35, 35, 35, 255);
    }

    // Update is called once per frame
    void Update()
    {
      // ColorChange();
        CountUp();
        //Debug.Log(_gageCount);
    }
    
    void ColorChange()
    {
        if (_gageCount == 0)
        {
            _gage[0].color = new Color(35, 35, 35, 255);
            _gage[1].color = new Color(35, 35, 35, 255);
            _gage[2].color = new Color(35, 35, 35, 255);
        }
        else if (_gageCount == 1)
        {
            _gage[0].color = new Color(255, 221, 204, 255);
            _gage[1].color = new Color(35, 35, 35, 255);
            _gage[2].color = new Color(35, 35, 35, 255);
        }
        else if (_gageCount == 2)
        {
            _gage[0].color = new Color(255, 221, 204, 255);
            _gage[1].color = new Color(255, 221, 204, 255);
            _gage[2].color = new Color(35, 35, 35, 255);
        }
        else if (_gageCount == 3)
        {
            _gage[0].color = new Color(255, 221, 204, 255);
            _gage[1].color = new Color(255, 221, 204, 255);
            _gage[2].color = new Color(255, 221, 204, 255);
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
