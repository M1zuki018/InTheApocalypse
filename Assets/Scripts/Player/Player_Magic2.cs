﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Player_Magic : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab = default; //魔法のプレハブ
    Vector3 _muzzlePosition; //魔法が出る位置の座標

    //与えられるダメージ量

    //MP関係
    public int _mpConsumption1; //魔法1の消費MP

    // Start is called before the first frame update
    void Start()
    {
        _muzzlePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MagicB();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(this.gameObject);
        }

        // マズルの位置を取得する
        _muzzlePosition = transform.position;
    }

    void MagicB()
    {
        if (PlayerController._mp >= _mpConsumption1)
        {
            Instantiate(_bulletPrefab, _muzzlePosition, Quaternion.identity);
            PlayerController._mp = PlayerController._mp - _mpConsumption1;
            Debug.Log("魔法2");
        }
        else if (PlayerController._mp < _mpConsumption1)
        {
            PlayerController._mpNotEnough = true;
            Invoke("FlagReset", 2);
        }
    }

    void FlagReset()
    {
        PlayerController._mpNotEnough = false;
    }
}
