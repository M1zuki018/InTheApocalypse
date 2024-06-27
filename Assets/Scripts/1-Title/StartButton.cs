using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.enabled = false;
        Invoke("ButtonActive", 5);
    }

    void ButtonActive()
    {
        _button.enabled = true;
    }
}
