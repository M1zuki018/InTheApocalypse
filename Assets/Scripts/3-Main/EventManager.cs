using Cinemachine;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    [SerializeField] GameObject _movePanel;
    [SerializeField] GameObject _event1Camera;
    bool _isFirst1;

    [Header("Event2：敵と遭遇")]
    bool _isFirst2;
    public bool _event2 = false;
    [SerializeField] bool _panel1;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Vector3 _sponePosition;
    GameObject _eventZone2;
    GameObject _enemySensor;
    [SerializeField] GameObject _event2Camera;
    [SerializeField] GameObject _event2AttackCamera;

    [Header("Event3：操作のチュートリアル")]
    bool _isFirst2_2;
    bool _isFirst2_3;
    bool _event2_2 = false;
    bool _event2_3;
    bool _panel2 = false;
    bool _panel3;
    [SerializeField] GameObject[] _event3Panels; //パネルを表示する
    bool _event2Battle;
    bool _event2_2Battle;
    bool _event2_3Battle;
    [SerializeField] Vector3 _sponePosition2_2;
    [SerializeField] Vector3 _sponePosition2_3;
    GameObject _eventZone4;

    [Header("Event4：バトル")]
    bool _event4;
    bool _isFirst4;
    bool _event4Battle;
    [SerializeField] Vector3 _sponePosition4;

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
        _inputController.PlayerStop();
    }

    void GetComponents() //componentを取得してくる
    {
        _textController = _txtCtrl.GetComponent<TextController>();
        _inputController = GetComponent<InputController>();
        _uiController = _uiCtrl.GetComponent<UIController>();

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

        ///<summary>
        /// Event1
        /// </summary>
        if (!_isFirst1)
        {
            if (!_textController._textArea.activeSelf)
            {
                _movePanel.SetActive(true); //移動の操作説明を出す
                _isFirst1 = true;
            }
        }
        //操作説明パネルが出ている&クリックされたら、パネルを消して動き始められるようにする
        if (_movePanel.activeSelf == true && Input.GetButtonDown("Fire1"))
        {
            MoveStart();
        }

        ///<summary>
        ///Event2
        /// </summary>

        //イベントコライダーに接触
        if (_event2 && !_isFirst2)
        {
            _isFirst2 = true;
            Event2();
        }

        //Event2()が呼び出される&テキストが再生し終わる
        if(_panel1 && !_textController._textArea.activeSelf)
        {
            Event2Panel();
        }

        if (_event2Battle)
        {
            Event2Battle();
        }

        ///<summary>
        /// Event2-2　操作説明②
        ///</summary>
        
        //Event2Battleが終わる
        if (_event2_2 && !_isFirst2_2)
        {
            Event2_2();
            _isFirst2_2 = true;
        }

        //Event2_2()が呼ばれる
        if (_panel2)
        {
            Event2_2Panel();
        }

        if (_event2_2Battle)
        {
            Event2_2Battle();
        }

        ///<summary>
        /// Event2-3　操作説明③
        ///</summary>

        //Event2_2Battle()が終わる
        if (_event2_3 && !_isFirst2_3)
        {
            Event2_3();
            _isFirst2_3 = true;
        }

        //Event2_3が呼ばれる
        if (_panel3)
        {
            Event2_3Panel();
        }

        if (_event2_3Battle)
        {
            Event2_3Battle();
        }

        //Event4 通常戦闘

        if (_event4 && !_isFirst4)
        {
            Event4();
            _isFirst4 = true;
        }

        if (_event4Battle)
        {
            Event4Battle();
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

    #region Event1
    //操作説明
    void MoveStart()
    {  
        _movePanel.SetActive(false);
        _event1Camera.SetActive(false);
        _inputController.MoveOnly();　//移動だけ
    }
    #endregion

    #region Event2 

    public void Event2()
    {
        //ストーリーを再生
        _textController.Event2Story();

        //敵を生成
        Instantiate(_enemyPrefab, _sponePosition, Quaternion.identity);
        GameObject enemy = GameObject.FindWithTag("Enemy");
        _enemySensor = enemy.transform.GetChild(0).gameObject;
        _enemySensor.SetActive(false);

        //カメラをプレイヤーとエネミーに合わせる
        _event2Camera.SetActive(true);
        CinemachineVirtualCamera event2cvc;
        event2cvc = _event2Camera.GetComponent<CinemachineVirtualCamera>();
        event2cvc.LookAt = enemy.transform;
        
        //操作を止める
        _inputController.PlayerStop();
        _panel1 = true;
    }

    void Event2Panel()
    {
        //操作説明①のパネルとUIを表示する
        _event3Panels[0].SetActive(true);
        _uiController.Group1();
        _uiController.Group2();
        Destroy(_eventZone2);

        //クリックしたら次の処理
        if (Input.GetButtonDown("Fire1"))
        {
            _event3Panels[0].SetActive(false);
            _event2Camera.SetActive(false);　//メインカメラに戻す
            _inputController.AttackOnly();
            _enemySensor.SetActive(true);

            _eventZone4.SetActive(true); //後ろの移動制限

            _event2Battle = true;　//バトルを始める
            _panel1 = false;
        }
    }

    void Event2Battle() //バトル中
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            _event2_2 = true;
            _event2Battle = false;
        }
    }
    #endregion

    #region Event2-2
    void Event2_2() //操作説明②
    {
        _inputController.PlayerStop();

        //スポーン
        Instantiate(_enemyPrefab, _sponePosition2_2, Quaternion.identity);
        GameObject enemy = GameObject.FindWithTag("Enemy");
        _enemySensor = enemy.transform.GetChild(0).gameObject;
        _enemySensor.SetActive(false);

        //カメラ
        _event2Camera.SetActive(true);
        CinemachineVirtualCamera event2cvc;
        event2cvc = _event2Camera.GetComponent<CinemachineVirtualCamera>();
        event2cvc.LookAt = enemy.transform;

        //操作説明パネルとUIを表示する
        _event3Panels[1].SetActive(true);
        _panel2 = true;
    }

    void Event2_2Panel()　//待機中
    {
        
        //クリックしたら次の処理
        if (Input.GetButtonDown("Fire1"))
        {
            _event3Panels[1].SetActive(false);
            _event2Camera.SetActive(false);
            _inputController.Event3();
            _enemySensor.SetActive(true);

            _event2_2Battle = true;
            _panel2 = false;
        }
    }

    void Event2_2Battle() //バトル中
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            _event2_3 = true;
            _event2_2Battle = false;
        }
    }
    #endregion

    #region Event2-3
    void Event2_3() //操作説明③
    {
        _inputController.PlayerStop();

        //スポーン
        Instantiate(_enemyPrefab, _sponePosition2_3, Quaternion.identity);
        GameObject enemy = GameObject.FindWithTag("Enemy");
        _enemySensor = enemy.transform.GetChild(0).gameObject;
        _enemySensor.SetActive(false);

        //カメラ
        _event2Camera.SetActive(true);
        CinemachineVirtualCamera event2cvc;
        event2cvc = _event2Camera.GetComponent<CinemachineVirtualCamera>();
        event2cvc.LookAt = enemy.transform;

        //操作説明パネルとUIを表示する
        _event3Panels[2].SetActive(true);
        _panel3 = true;
    }

    void Event2_3Panel()
    {
        //クリックしたら次の処理
        if (Input.GetButtonDown("Fire1"))
        {
            _event3Panels[2].SetActive(false);
            _event2Camera.SetActive(false);
            _inputController.Event3_2();
            _enemySensor.SetActive(true);

            _event2_3Battle = true;
            _panel3 = false;
        }
    }

    void Event2_3Battle() //Battle
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(_eventZone4);
            _event4 = true;
            _event2_3Battle = false;
        }
    }
    #endregion

    #region Event4
    void Event4()
    {
        Instantiate(_enemyPrefab, _sponePosition4, Quaternion.identity);
        _event4Battle = true;
        
    }

    void Event4Battle()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            Destroy(_eventZone4);
            _event5 = true;
            _event4Battle = false;
        }
    }
    #endregion

    #region Event5

    public void Event5()
    {
        _textController.Event5Story();
        _inputController.PlayerStop();
        StartCoroutine("Event5Coroutine");
    }

    IEnumerator Event5Coroutine()
    {
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
