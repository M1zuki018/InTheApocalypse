using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SkillChange : MonoBehaviour
{
    public GameObject[] _skill = new GameObject[4]; //スキルのオブジェクトをしまう配列
    int _count;

    Vector3 _initialPosition; //初期位置

    void Start()
    {
        _skill[0].SetActive(true);
        _skill[1].SetActive(true);
        _skill[2].SetActive(false);
        _skill[3].SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SkillSet();
        }
    }

    void SkillSet()
    {
        _count++;

        if(_count % 2 == 1)
        {
            _skill[0].SetActive(false);
            _skill[1].SetActive(false);
            _skill[2].SetActive(true);
            _skill[3].SetActive(true);
        }
        else
        {
            _skill[0].SetActive(true);
            _skill[1].SetActive(true);
            _skill[2].SetActive(false);
            _skill[3].SetActive(false);
        }
    }
}
