using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppaEventTrigger : MonoBehaviour
{
    GameObject _eventManagerObj;
    Main2_EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _eventManagerObj = GameObject.Find("EventManager");
        _eventManager = _eventManagerObj.GetComponent<Main2_EventManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _eventManager._zeppaEvent = true;
    }
}
