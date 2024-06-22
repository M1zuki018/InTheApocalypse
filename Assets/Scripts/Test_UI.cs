using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_UI : MonoBehaviour
{
    UIController _uiController;
    bool _isFirst;
    // Start is called before the first frame update
    void Start()
    {
        _uiController = GetComponent<UIController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isFirst)
        {
            _uiController.Group1();
            _uiController.Group2();
            _isFirst = true;
        }
        
    }
}
