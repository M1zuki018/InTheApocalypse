using Cinemachine;
using System.Collections;
using UnityEngine;

public class Main2_EventManager : MonoBehaviour
{
    [SerializeField] GameObject _txtCtrl;
    TextController _textController;
    InputController _inputController;

    [SerializeField] GameObject _uiCtrl;
    UIController _uiController;

    [Header("Buttle1")]
    public bool _battle1;
    bool _isFirst1;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Vector3 _sponePosition;
    [SerializeField] Vector3 _sponePosition2;
    GameObject _battle1Col1;
    GameObject _battle1Col2;

    [Header("スーパー絶刃タイム")]
    public bool _zeppaEvent;
    bool _zeppaEvent3; //操作説明
    bool _zeppaBattle;
    bool _zeppaTalk;
    bool _isFirst2;
    bool _isFirst2_2;
    bool _isFirst2_3;
    bool _explanation;
    [SerializeField] int _zeppaEventStopSeconds = 5;
    [SerializeField] float _zeppaEventStopSeconds3 = 0.1f;
    [SerializeField] Vector3 _sponePosition3;
    [SerializeField] Vector3 _sponePosition4;
    [SerializeField] Vector3 _sponePosition5;
    [SerializeField] Vector3 _sponePosition6;
    [SerializeField] Vector3 _sponePosition7;
    [SerializeField] GameObject _zeppaPanel;
    [SerializeField] GameObject _authorityGage;
    GameObject _zeppaEventCol;
    //GameObject _zeppaEventCol2;

    [Header("会話シーン")]
    [SerializeField] int _talkStopSeconds;

    [Header("Buttle2")]
    public bool _battle2;
    bool _isFirst3;
    [SerializeField] GameObject _enemyPrefab2;
    [SerializeField] Vector3 _sponePosition8;
    [SerializeField] Vector3 _sponePosition9;
    GameObject _battle1Col3;
    GameObject _battle1Col4;


    [Header("Buttle3")]
    public bool _battle3;
    bool _isFirst4;
    [SerializeField] Vector3 _sponePosition10;
    [SerializeField] Vector3 _sponePosition11;
    GameObject _battle1Col5;
    GameObject _battle1Col6;

    [Header("Camera")]
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _nearCamera;
    [SerializeField] GameObject _eventCamera;

    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
        Initialization();
    }

    void GetComponents()
    {
        _textController = _txtCtrl.GetComponent<TextController>();
        _inputController = GetComponent<InputController>();
        _uiController = _uiCtrl.GetComponent<UIController>();

        _battle1Col1 = GameObject.Find("Battle1Col1");
        _battle1Col2 = GameObject.Find("Battle1Col2");
        _battle1Col3 = GameObject.Find("Battle1Col3");
        _battle1Col4 = GameObject.Find("Battle1Col4");
        _battle1Col5 = GameObject.Find("Battle1Col5");
        _battle1Col6 = GameObject.Find("Battle1Col6");
        _zeppaEventCol = GameObject.Find("ZeppaEvent");
        //   _zeppaEventCol2 = GameObject.Find("ZeppaEventCol2");
    }

    void Initialization()
    {
        _battle1Col1.SetActive(false);
        _battle1Col3.SetActive(false);
        _battle1Col5.SetActive(false);

        _textController.Enabled();
        _textController.enabled = false;

        _uiController.Group1();
        _uiController.Group2();
        _authorityGage.SetActive(false);

        _inputController.PlayerAwake();

        _mainCamera.SetActive(true);
        _nearCamera.SetActive(false);
        _eventCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_battle1)
        {
            if (!_isFirst1)
            {
                Instantiate(_enemyPrefab, _sponePosition, Quaternion.identity);
                Instantiate(_enemyPrefab, _sponePosition2, Quaternion.identity);
                _battle1Col1.SetActive(true);
                _battle1Col2.SetActive(true);
                _isFirst1 = true;
            }
            Battle1();
        }

        #region 絶刃イベント
        if (_zeppaEvent && !_isFirst2)
        {
            _isFirst2 = true;
            ZeppaEvent();
        }

        //テキストカウントが丸になったらZeppaEvent_2()
        if(_textController._textcount == 9 && !_isFirst2_2)
        {
            ZeppaEvent_2();
            _isFirst2_2 = true;
        }

        if(_zeppaEvent3 && !_textController._textArea.activeSelf && !_isFirst2_3)
        {
            ZeppaEvent_3();
            _isFirst2_3 = true;
        }

        if (_explanation)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _zeppaPanel.SetActive(false);
                Destroy(_zeppaEventCol);
                StartCoroutine("ZeppaEvent2");
                _explanation = false;
            }
        }

        if (_zeppaBattle)
        {
            ZeppaBattle();
        }

        if (_zeppaTalk && !_textController._textArea.activeSelf)
        {
            _textController.Enabled();
            _textController.enabled = false;
        }

        #endregion

        if (_battle2)
        {
            if (!_isFirst3)
            {
                Instantiate(_enemyPrefab2, _sponePosition8, Quaternion.identity);
                Instantiate(_enemyPrefab2, _sponePosition9, Quaternion.identity);
                _battle1Col3.SetActive(true);
                _battle1Col4.SetActive(true);
                _isFirst3 = true;
            }
            Battle2();
        }

        if (_battle3)
        {
            if (!_isFirst4)
            {
                Instantiate(_enemyPrefab2, _sponePosition10, Quaternion.identity);
                Instantiate(_enemyPrefab2, _sponePosition11, Quaternion.identity);
                _battle1Col5.SetActive(true);
                _battle1Col6.SetActive(true);
                _isFirst4 = true;
            }
            Battle3();
        }
    }
    void Battle1() //通常戦闘
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(GameObject.Find("Battle1"));
            _battle1 = false;
        }
    }

    #region 絶刃イベント
    void ZeppaEvent()
    {
        _inputController.PlayerStop();

        //テキストをセットする
        _textController.enabled = true;
        _textController.Set();
        _textController.ZeppaStory();

        _mainCamera.SetActive(false);
        _nearCamera.SetActive(true);

        StartCoroutine(ZeppaEvent_1());
    }

    IEnumerator ZeppaEvent_1()
    {
        yield return new WaitForSeconds(_zeppaEventStopSeconds); //どばーっと流れる演出

        _textController.ZeppaStory1_2();

        yield break;
    }

    void ZeppaEvent_2()
    {
        //敵を出現させる
        Instantiate(_enemyPrefab, _sponePosition3, Quaternion.identity);
        GameObject enemy = GameObject.FindWithTag("Enemy");
        Instantiate(_enemyPrefab, _sponePosition4, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition5, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition6, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition7, Quaternion.identity);

        _nearCamera.SetActive(false);
        _eventCamera.SetActive(true);
        CinemachineVirtualCamera eventcvc;
        eventcvc = _eventCamera.GetComponent<CinemachineVirtualCamera>();
    
        eventcvc.Follow = enemy.transform;

        _zeppaEvent3 = true;
    }

    void ZeppaEvent_3()
    {
        _eventCamera.SetActive(false);
        _mainCamera.SetActive(true);

        //権限の説明を表示する
        _zeppaPanel.SetActive(true);
        _authorityGage.SetActive(true);
        AuthorityGage._gageCount = 1;
        _explanation = true;
    }

    IEnumerator ZeppaEvent2()
    {
        //ストーリーが進む

        yield return new WaitForSeconds(_zeppaEventStopSeconds3);

        _inputController.AuthortySkill();
        _inputController.PlayerAwake();
        _zeppaBattle = true;

    }

    void ZeppaBattle()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            _zeppaBattle = false;
            ZeppaTalk();
        }
    }

    void ZeppaTalk()
    {
        _textController.Talk();
        _zeppaTalk = true;
    }

    #endregion

    void Battle2() //通常戦闘
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(GameObject.Find("Battle2"));
            _battle2 = false;
        }
    }

    void Battle3() //通常戦闘
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(GameObject.Find("Battle3"));
            _battle3 = false;
        }
    }
}
