using System.Collections;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Finish
    [SerializeField] GameObject _txtCtrl;
    TextController _textController;
    InputController _inputController;

    [SerializeField] GameObject _uiCtrl;
    UIController _uiController;

    [Header("Event1：スタート時のイベント")]
    public bool _event1;
    [SerializeField] int _event1StopSeconds;

    [Header("Event2：敵と遭遇")]
    bool _isFirst2;
    public bool _event2;
    [SerializeField] int _event2StopSeconds;
    //敵をスポーンさせる
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Vector3 _sponePosition;
    //カメラを動かす
    #endregion

    [Header("Event3：操作のチュートリアル")]
    public bool _event3;
    [SerializeField] GameObject _event3PanelArea;
    SpriteRenderer _event3Panel;
    [SerializeField] Sprite[] _event3Panels; //パネルを表示する
    int _panelIndex;
    //終わったら行動できるようにする

    [Header("Event4：バトル①")]
    public bool _event4;

    [Header("Event5：バトル後の会話")]
    public bool _event5;
    bool _isFirst5;
    [SerializeField] int _event5StopSeconds;

    [Header("Event6：バトル③")]
    public bool _event6;
    bool _isFirst6;
    [SerializeField] Vector3 _sponePosition2;
    [SerializeField] Vector3 _sponePosition3;
    //敵を沸かせる

    [Header("Event7：バトル③")]
    public bool _event7;
    //敵を沸かせる

    // Start is called before the first frame update
    void Start()
    {
        _textController = _txtCtrl.GetComponent<TextController>();
        _inputController = GetComponent<InputController>();
        _uiController = _uiCtrl.GetComponent<UIController>();

        _event3Panel = _event3PanelArea.GetComponent<SpriteRenderer>();

        _event1 = true;
        StartCoroutine("Event1");

    }
    void Update()
    {
        if (_event2 && !_isFirst2)
        {
            _isFirst2 = true;
            Event2();
        }

        if (_event3)
        {
            Event3();
        }

        if(_event4)
        {
            Event4();
        }

        if (_event5 && !_isFirst5)
        {
            _isFirst5 = true;
            Event5();
        }

        if (_event6 && !_isFirst6)
        {
            _isFirst6 = true;
            Event6();
        }
    }

    IEnumerator Event1()
    {
        _inputController.PlayerStop();

        yield return new WaitForSeconds(_event1StopSeconds);

        _inputController.PlayerAwake();

        yield break;
    }

    #region Event2

    public void Event2()
    {
        _textController.Event2Story();
        Instantiate(_enemyPrefab, _sponePosition, Quaternion.identity);
        StartCoroutine("Event2Coroutine");
    }

    IEnumerator Event2Coroutine()
    {
        _inputController.PlayerStop();

        EnemyController enemyController = _enemyPrefab.GetComponent<EnemyController>();
        enemyController.enabled = false;

        yield return new WaitForSeconds(_event2StopSeconds);

        _event3Panel.sprite = _event3Panels[0];
        _uiController.Group1();
        _uiController.Group2();
        _event3 = true;
        Destroy(GameObject.Find("Event2-5"));

        yield break;
    }
    #endregion

    void Event3()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _panelIndex++;

        }

        if (_panelIndex >= _event3Panels.Length)
        {
            Destroy(_event3PanelArea);
            _inputController.PlayerAwake();
            EnemyController enemyController = _enemyPrefab.GetComponent<EnemyController>();
            enemyController.enabled = true;
            _event4 = true;
            _event3 = false;
            return;
        }
            _event3Panel.sprite = _event3Panels[_panelIndex];
    }

    void Event4()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemys.Length == 0)
        {
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

    void Event6()
    {
        Instantiate(_enemyPrefab, _sponePosition2, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition3, Quaternion.identity);

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(GameObject.Find("Event6"));
            _event6 = false;
        }
    }
}
