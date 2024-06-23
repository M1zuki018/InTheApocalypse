using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle3Trigger : MonoBehaviour
{
    GameObject _eventManagerObj;
    Main2_EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _eventManagerObj = GameObject.Find("EventManager");
        _eventManager = _eventManagerObj.GetComponent<Main2_EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _eventManager._battle3 = true;
        }
    }
}