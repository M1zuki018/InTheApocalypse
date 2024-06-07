using UnityEngine;

public class NextText : MonoBehaviour
{
    GameObject _textControllerObj;
    TextController _textController;
    public GameObject _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _textControllerObj = GameObject.Find("TextController");
        _textController = _textControllerObj.GetComponent<TextController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _textController.NextStory();
        Instantiate(_enemy);
    }
}
