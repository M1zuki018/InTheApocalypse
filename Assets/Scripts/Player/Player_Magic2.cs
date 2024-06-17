using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Player_Magic2 : MonoBehaviour
{

    //MP関係
    public int _mpConsumption1; //魔法1の消費MP
    GameObject _mpController;

    GameObject _seObj;
    Main1_SEController _seController;

    // Start is called before the first frame update
    void Start()
    {
        _mpController = GameObject.Find("MpObj");
        _seObj = GameObject.Find("SE");
        _seController = _seObj.GetComponent<Main1_SEController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MagicB();
        }

    }

    void MagicB()
    {
        _mpController.TryGetComponent(out EnvironmentMp mp);

        if (mp._mp >= _mpConsumption1 || PlayerController._chara1HP >= 100)
        {
            mp._mp = mp._mp - _mpConsumption1;
            _seController.Magic2();
            PlayerController._chara1HP = PlayerController._chara1HP + 10;
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
