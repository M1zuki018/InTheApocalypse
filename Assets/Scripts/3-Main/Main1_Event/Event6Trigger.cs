using UnityEngine;

public class Event6Trigger : MonoBehaviour
{
    GameObject _eventManagerObj;
    EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _eventManagerObj = GameObject.Find("EventManager");
        _eventManager = _eventManagerObj.GetComponent<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _eventManager._event6 = true;
        }

    }
}