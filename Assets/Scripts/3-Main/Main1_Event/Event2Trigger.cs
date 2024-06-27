using UnityEngine;

public class Event2Trigger : MonoBehaviour
{
    GameObject _eventManagerObj;
    EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _eventManagerObj = GameObject.Find("EventManager");
        _eventManager = _eventManagerObj.GetComponent<EventManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            _eventManager._event2 = true;
        }
        
    }
}
