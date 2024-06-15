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
    [SerializeField] int _zeppaEventStopSeconds;
    [SerializeField] int _zeppaEventStopSeconds2;
    [SerializeField] int _zeppaEventStopSeconds3;
    [SerializeField] Vector3 _sponePosition3;
    [SerializeField] Vector3 _sponePosition4;
    [SerializeField] Vector3 _sponePosition5;
    [SerializeField] Vector3 _sponePosition6;
    [SerializeField] Vector3 _sponePosition7;
    [SerializeField] GameObject _zeppaPanel;
    GameObject _zeppaEventCol;
  //GameObject _zeppaEventCol2;

    [Header("会話シーン")]
    [SerializeField] int _talkStopSeconds;

    //[Header("Buttle2")]

    //[Header("Buttle3")]




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
        _zeppaEventCol = GameObject.Find("ZeppaEvent");
   //   _zeppaEventCol2 = GameObject.Find("ZeppaEventCol2");
    }

    void Initialization()
    {
        _battle1Col1.SetActive(false);
        _textController.Enabled();
        _textController.enabled =false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(_battle1)
        {
            if(!_isFirst1)
            {
                _uiController.Group1();
                _uiController.Group2();
                Instantiate(_enemyPrefab, _sponePosition, Quaternion.identity);
                Instantiate(_enemyPrefab, _sponePosition2, Quaternion.identity);
                _battle1Col1.SetActive(true);
                _battle1Col2.SetActive(true);
                _isFirst1 = true;
            }
            Battle1();
        }

        if(_zeppaEvent && !_isFirst2)
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

        yield return new WaitForSeconds(_zeppaEventStopSeconds);

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

        yield return new WaitForSeconds(_talkStopSeconds);

        _inputController.PlayerAwake();
    }
}
