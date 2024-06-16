using UnityEngine;

public class Date_UIController : MonoBehaviour
{

    [SerializeField] GameObject[] _list;
    int _listIndex;
    [SerializeField] GameObject[] _text;

    SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        _text[1].SetActive(false);
        _text[2].SetActive(false);
        _text[3].SetActive(false);
        _text[4].SetActive(false);
        _text[5].SetActive(false);
        _text[6].SetActive(false);
        _text[7].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Index();
        TextChange();
    }

    void Index()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_listIndex == 0)
            {
                return;
            }
            _listIndex--;
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (_listIndex == 7)
            {
                return;
            }
            _listIndex++;
        }
    }

    void TextChange()
    {
        if(_listIndex == 0)
        {
            _text[0].SetActive(true);
            _text[1].SetActive(false);
        }
        else if (_listIndex == 1)
        {
            _text[0].SetActive(false);
            _text[1].SetActive(true);
            _text[2].SetActive(false);
        }
        else if (_listIndex == 2)
        {
            _text[1].SetActive(false);
            _text[2].SetActive(true);
            _text[3].SetActive(false);
        }
        else if (_listIndex == 3)
        {
            _text[2].SetActive(false);
            _text[3].SetActive(true);
            _text[4].SetActive(false);
        }
        else if (_listIndex == 4)
        {
            _text[3].SetActive(false);
            _text[4].SetActive(true);
            _text[5].SetActive(false);
        }
        else if (_listIndex == 5)
        {
            _text[4].SetActive(false);
            _text[5].SetActive(true);
            _text[6].SetActive(false);
        }
        else if (_listIndex == 6)
        {
            _text[5].SetActive(false);
            _text[6].SetActive(true);
            _text[7].SetActive(false);
        }
        else if (_listIndex == 7)
        {
            _text[6].SetActive(false);
            _text[7].SetActive(true);
        }
    }
}
