using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    bool _zeppaBattle;
    bool _isFirst2;
    bool _explanation;
    [SerializeField] int _zeppaEventStopSeconds = 16;
    [SerializeField] int _zeppaEventStopSeconds2 = 20;
    [SerializeField] int _zeppaEventStopSeconds3;
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
        _textController.enabled =false;
        _uiController.Group1();
        _uiController.Group2();
        _authorityGage.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(_battle1)
        {
            if(!_isFirst1)
            {
                Instantiate(_enemyPrefab, _sponePosition, Quaternion.identity);
                Instantiate(_enemyPrefab, _sponePosition2, Quaternion.identity);
                _battle1Col1.SetActive(true);
                _battle1Col2.SetActive(true);
                _isFirst1 = true;
            }
            Battle1();
        }

        if (_zeppaEvent && !_isFirst2)
        {
            _isFirst2 = true;
            StartCoroutine("ZeppaEvent");
        }

        if(_explanation)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _zeppaPanel.SetActive(false);
                Destroy(_zeppaEventCol);
                StartCoroutine("ZeppaEvent2");
                _explanation = false;
            }
        }

        if(_zeppaBattle)
        {
            ZeppaBattle();
        }

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

    IEnumerator ZeppaEvent()
    {
        //ストーリーを流す
        _inputController.PlayerStop();
        _textController.enabled = true;
        _textController.Set();
        _textController.ZeppaStory();

        yield return new WaitForSeconds(_zeppaEventStopSeconds);

        _textController.ZeppaStory1_2();

        yield return new WaitForSeconds(_zeppaEventStopSeconds2);

        //敵を出現させる
        Instantiate(_enemyPrefab, _sponePosition3, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition4, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition5, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition6, Quaternion.identity);
        Instantiate(_enemyPrefab, _sponePosition7, Quaternion.identity);

        //ストーリーが進む

        yield return new WaitForSeconds(_zeppaEventStopSeconds2);

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
            StartCoroutine("Talk");
        }
    }

    IEnumerator Talk()
    {
        _inputController.PlayerStop();
        _textController.Talk();

        yield return new WaitForSeconds(_talkStopSeconds);

        _inputController.PlayerAwake();
    }

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
