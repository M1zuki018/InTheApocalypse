using Cinemachine;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    GameObject _bossObj;
    CinemachineVirtualCamera _cvc;

    // Start is called before the first frame update
    void Update()
    {
        if(_bossObj == null)
        {
            _bossObj = GameObject.FindWithTag("Boss");
            _cvc = GetComponent<CinemachineVirtualCamera>();
            _cvc.Follow = _bossObj.transform;
        }
    }
}
