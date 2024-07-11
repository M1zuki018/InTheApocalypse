using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject _a;
    bool _isFirst;
    // Start is called before the first frame update
    void Start()
    {
        _a.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
