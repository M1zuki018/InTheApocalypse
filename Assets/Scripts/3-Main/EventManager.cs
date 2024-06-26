using Cinemachine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region 宣言
    [SerializeField] GameObject _txtCtrl;
    TextController _textController;
    InputController _inputController;

    [SerializeField] GameObject _uiCtrl;
    UIController _uiController;

    [SerializeField] GameObject _mainCamera;

    [Header("Event1：スタート時のイベント")]
    [SerializeField] int _event1StopSeconds;
    [SerializeField] GameObject _movePanel;
    [SerializeField] GameObject _event1Camera;

    [Header("Event2：敵と遭遇")]
    bool _isFirst2;
    public bool _event2;
    [SerializeField] int _event2StopSeconds;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Vector3 _sponePosition;
    GameObject _eventZone2;
    GameObject _enemySensor;
    [SerializeField] GameObject _event2Camera;

    [Header("Event3：操作のチュートリアル")]
    bool _event3;
    GameObject _event3PanelArea;
    SpriteRenderer _event3Panel;
    [SerializeField] Sprite[] _event3Panels; //パネルを表示する
    int _panelIndex;

    [Header("Event4：バトル①")]
    bool _event4;
    GameObject _eventZone4;

    [Header("Event5：バトル後の会話")]
    bool _event5;
    bool _isFirst5;
    [SerializeField] int _event5StopSeconds;

    [Header("Event6：バトル②")]
    public bool _event6;
    bool _isFirst6;
    [SerializeField] Vector3 _sponePosition2;
    [SerializeField] Vector3 _sponePosition3;
    GameObject _event6Col1;
    GameObject _event6Col2;

    [Header("Event7：バトル③")]
    public bool _event7;
    //敵を沸かせる

    #endregion

    void Start()
    {
        GetComponents();
        Initialization();
        StartCoroutine("Event1");
    }

    void GetComponents() //componentを取得してくる
    {
        _textController = _txtCtrl.GetComponent<TextController>();
        _inputController = GetComponent<InputController>();
        _uiController = _uiCtrl.GetComponent<UIController>();

        _event3PanelArea = GameObject.Find("Event3SpriteArea");
        _event3Panel = _event3PanelArea.GetComponent<SpriteRenderer>();

        _eventZone2 = GameObject.Find("Event2-5");
        _eventZone4 = GameObject.Find("Event4");
        _event6Col1 = GameObject.Find("Event6col1");
        _event6Col2 = GameObject.Find("Event6col2");
    }

    void Initialization()
    {
        _movePanel.SetActive(false);
        _eventZone4.SetActive(false);
        _event6Col1.SetActive(false);
        _event6Col2.SetActive(false);
    }

    void Update()
    {
        if (_movePanel.activeSelf == true && Input.GetButtonDown("Fire1"))
        {
            MoveStart();
        }

        if (_event2 && !_isFirst2)
        {
            _isFirst2 = true;
            Event2();
        }

        if (_event3)
        {
            Event3();
        }

        if (_event4)
        {
            Event4();
        }

        if (_event5 && !_isFirst5)
        {
            _isFirst5 = true;
            Event5();
        }

        if (_event6)
        {
            if (!_isFirst6)
            {
                Instantiate(_enemyPrefab, _sponePosition2, Quaternion.identity);
                Instantiate(_enemyPrefab, _sponePosition3, Quaternion.identity);
                _event6Col1.SetActive(true);
                _event6Col2.SetActive(true);
                _isFirst6 = true;
            }
            Event6();
        }
    }

    IEnumerator Event1()
    {
        _inputController.PlayerStop();

        yield return new WaitForSeconds(_event1StopSeconds);

        _movePanel.SetActive(true);

        yield break;
    }

    void MoveStart()
    {
        _movePanel.SetActive(false);
        _event1Camera.SetActive(false);
        _inputController.PlayerAwake();
    }

    #region Event2

    public void Event2()
    {
        _textController.Event2Story();
        Instantiate(_enemyPrefab, _sponePosition, Quaternion.identity);
        _enemySensor = _enemyPrefab.transform.GetChild(0).gameObject;
        _enemySensor.SetActive(false);
        _event2Camera.SetActive(true);
        CinemachineVirtualCamera event2cvc;
        event2cvc = _event2Camera.GetComponent<CinemachineVirtualCamera>();
        GameObject enemy = GameObject.FindWithTag("Enemy");
        event2cvc.LookAt = enemy.transform;
        StartCoroutine("Event2Coroutine");
    }

    IEnumerator Event2Coroutine()
    {
        _inputController.PlayerStop();

        yield return new WaitForSeconds(_event2StopSeconds);

        _event3Panel.sprite = _event3Panels[0];
        _uiController.Group1();
        _uiController.Group2();
        _event3 = true;
        Destroy(_eventZone2);

        yield break;
    }
    #endregion

    void Event3() //操作のチュートリアルを表示する
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _panelIndex++;

        }

        if (_panelIndex >= _event3Panels.Length)
        {
            Destroy(_event3PanelArea);
            _event2Camera.SetActive(false);
            _inputController.PlayerAwake();
            _enemySensor.SetActive(true);

            _eventZone4.SetActive(true);
            _event4 = true;
            _event3 = false;
            return;
        }
        _event3Panel.sprite = _event3Panels[_panelIndex];
    }

    void Event4() //バトル
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(_eventZone4);
            _event5 = true;
            _event4 = false;
        }
    }
   
    #region Event5

    public void Event5()
    {
        _textController.Event5Story();
        StartCoroutine("Event5Coroutine");
    }

    IEnumerator Event5Coroutine()
    {
        _inputController.PlayerStop();

        yield return new WaitForSeconds(_event5StopSeconds);

        _inputController.PlayerAwake();
        _event5 = false;

        yield break;
    }
    #endregion

    void Event6() //通常戦闘
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(GameObject.Find("Event6"));
            _event6 = false;
        }
    }
}
