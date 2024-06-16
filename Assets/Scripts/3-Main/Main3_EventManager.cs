using System.Collections;
using UnityEngine;

public class Main3_EventManager : MonoBehaviour
{
    #region 宣言
    [SerializeField] GameObject _txtCtrl;
    TextController _textController;
    InputController _inputController;

    [SerializeField] GameObject _uiCtrl;
    UIController _uiController;

    AudioSource _audio;
    Scene _scene;

    [Header("Event1：会話のあとBGMを止める・BOSSを沸かせる")]
    [SerializeField] int _event1StopSeconds;
    [SerializeField] GameObject _bossPrefab;
    [SerializeField] Vector3 _bossSponePosition;

    [Header("Event2：会話・BGMをつける")]
    public bool _event2;
    [SerializeField] int _event2StopSeconds;
    [SerializeField] AudioClip _bossBGM;

    [Header("Event3：戦闘開始")]
    [SerializeField] int _event3StopSeconds;

    [Header("Event4：討伐")]
    bool _event4;


    #endregion

    void Start()
    {
        GetComponents();
        StartCoroutine("Event1");
        _textController.Enabled();
        _textController.enabled = false;
    }

    void GetComponents() //componentを取得してくる
    {
        _textController = _txtCtrl.GetComponent<TextController>();
        _inputController = GetComponent<InputController>();
        _uiController = _uiCtrl.GetComponent<UIController>();
        GameObject audioObj = GameObject.Find("Audio");
        _audio = audioObj.GetComponent<AudioSource>();
        _scene = GetComponent<Scene>();
    }


    void Update()
    {

        if (_event4)
        {
            Event4();
        }

    }

    IEnumerator Event1() //会話のあとBGMを止める・BOSSを沸かせる
    {
        _inputController.PlayerStop();

        yield return new WaitForSeconds(_event1StopSeconds);

        _audio.Stop();
        Instantiate(_bossPrefab, _bossSponePosition, Quaternion.identity);
        EnemyController enemyController = _bossPrefab.GetComponent<EnemyController>();
        enemyController.enabled = false;
        StartCoroutine("Event2");
        yield break;
    }

    IEnumerator Event2() //会話・BGMをつける
    {
        yield return new WaitForSeconds(_event2StopSeconds);

        _audio.clip = _bossBGM;
        _audio.Play();
        StartCoroutine("Event3");
        yield break;
    }

    IEnumerator Event3()
    {
        yield return new WaitForSeconds(_event3StopSeconds);

        _inputController.PlayerAwake();
        EnemyController enemyController = _bossPrefab.GetComponent<EnemyController>();
        enemyController.enabled = true;
        _event4 = true;
    }

    void Event4() //バトル
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            _scene.SceneChange();
            _event4 = false;
        }
    }

}
