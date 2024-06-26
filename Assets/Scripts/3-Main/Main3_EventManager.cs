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
    [SerializeField] GameObject _authorityGage;

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
    [SerializeField] GameObject _bossSlider;
    [SerializeField] int _event3StopSeconds;

    [Header("Event4：討伐")]
    bool _event4;

    [Header("End")]
    [SerializeField] AudioClip _endBGM;
    [SerializeField] int _endStopSeconds;
    [SerializeField] GameObject _fadePanel;


    #endregion

    void Start()
    {
        GetComponents();
        StartCoroutine("Event1");

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
        _textController.Main3();

        yield return new WaitForSeconds(_event1StopSeconds);

        _audio.Stop();
        Instantiate(_bossPrefab, _bossSponePosition, Quaternion.identity);
        GameObject boss = GameObject.FindWithTag("Boss");
        Boss_Attack bossAttack = boss.GetComponent<Boss_Attack>();
        bossAttack.enabled = false;
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

        _bossSlider.SetActive(true);
        _authorityGage.SetActive(true);
        _uiController.Group1();
        _uiController.Group2();
        _inputController.PlayerAwake();
        GameObject boss = GameObject.FindWithTag("Boss");
        Boss_Attack bossAttack = boss.GetComponent<Boss_Attack>();
        bossAttack.enabled = true;
        _event4 = true;
    }

    void Event4() //バトル
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Boss");

        if (enemys.Length == 0)
        {
            GameObject[] underlings = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in underlings)
            {
                Destroy(enemy);
            }
            StartCoroutine("EndScene");
            _event4 = false;
        }
    }

    IEnumerator EndScene()
    {
        _inputController.PlayerStop();
        GameObject uiCanvas = GameObject.Find("UICanvas");
        uiCanvas.SetActive(false);
        _audio.clip = _endBGM;
        _audio.Play();
        _textController.Main3End();

        yield return new WaitForSeconds(_endStopSeconds);

        _fadePanel.SetActive(true); //暗転アニメーション

        yield return new WaitForSeconds(7);

        _scene.SceneChange();
    }
}
