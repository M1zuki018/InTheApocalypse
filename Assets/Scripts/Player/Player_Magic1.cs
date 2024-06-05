using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Player_Magic1 : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab = default; //魔法のプレハブ
    Vector3 _muzzlePosition; //魔法が出る位置の座標

    //MP関係
    public int _mpConsumption1; //魔法1の消費MP
    GameObject _player;

    GameObject _mpController;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _muzzlePosition = _player.transform.position;

        _mpController = GameObject.Find("MpObj");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MagicA();
        }

        // マズルの位置を取得する
        _muzzlePosition = _player.transform.position;
    }

    void MagicA()
    {
        _mpController.TryGetComponent(out EnvironmentMp mp);

        if (mp._mp >= _mpConsumption1)
        {
            Instantiate(_bulletPrefab, _muzzlePosition, Quaternion.identity);
            mp._mp = mp._mp - _mpConsumption1;
            //Debug.Log("魔法1");
        }
        else if (mp._mp < _mpConsumption1)
        {
            mp._mpNotEnough = true;
            Invoke("FlagReset", 3);
        }
    }

    void FlagReset()
    {
        _mpController.TryGetComponent(out EnvironmentMp mp);
        mp._mpNotEnough = false;
    }
}
