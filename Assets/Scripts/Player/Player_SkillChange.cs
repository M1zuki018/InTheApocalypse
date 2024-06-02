using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SkillChange : MonoBehaviour
{
    public GameObject[] _skill = new GameObject[4]; //スキルプレハブをしまう配列
    private int _currentPrefabIndex1 = 1;
    private int _currentPrefabIndex2 = 0;

    GameObject _skill1;
    GameObject _skill2;

    Vector3 _initialPosition; //初期位置

    void Start()
    {
        _initialPosition = this.transform.position; //オブジェクトの生成位置を初期位置にセット

        //最初のスキルセット（物理型）
        _skill1 = Instantiate(_skill[0], _initialPosition, Quaternion.identity); 
        _skill2 = Instantiate(_skill[1], _initialPosition, Quaternion.identity); 
        _skill1.transform.parent = transform;
        _skill2.transform.parent = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SkillSet();
        }
    }

    void SkillSet()
    {
        _currentPrefabIndex1 = (_currentPrefabIndex1 + 2) % _skill.Length;
        _currentPrefabIndex2 = (_currentPrefabIndex2 + 2) % _skill.Length;
        _skill1 = Instantiate(_skill[_currentPrefabIndex1], _initialPosition, Quaternion.identity);
        _skill2 = Instantiate(_skill[_currentPrefabIndex2], _initialPosition, Quaternion.identity);
        _skill1.transform.parent = transform;
        _skill2.transform.parent = transform;
    }
}
