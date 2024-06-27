using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main3_MainCamera : MonoBehaviour
{
    GameObject _bossObj;
    CinemachineVirtualCamera _cvc;

    // Update is called once per frame
    void Update()
    {
        if (_bossObj == null)
        {
            _bossObj = GameObject.FindWithTag("Boss");
            _cvc = GetComponent<CinemachineVirtualCamera>();
            _cvc.LookAt = _bossObj.transform;
        }
    }
}
