using UnityEngine;

public class TextSkip : MonoBehaviour
{
    TextController _textController;

    // Start is called before the first frame update
    void Start()
    {
        _textController = GetComponent<TextController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && _textController._textcount <= _textController._number - 1)
        {
            _textController.TextUpdate();
        }
    }
}
