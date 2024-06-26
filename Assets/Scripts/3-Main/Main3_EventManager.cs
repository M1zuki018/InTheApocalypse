﻿using UnityEngine;

public class Main3_EventManager : MonoBehaviour
{
    #region 宣言
    [SerializeField] GameObject _txtCtrl;
    TextController _textController;
    TextSkip _textSkip;
    InputController _inputController;

    [SerializeField] GameObject _uiCtrl;
    UIController _uiController;
    [SerializeField] GameObject _authorityGage;

    AudioSource _audio;
    Scene _scene;

    [Header("Event1：会話のあとBGMを止める・BOSSを沸かせる")]
    bool _event1;
    bool _isFirst1;
    [SerializeField] GameObject _bossPrefab;

    [Header("Event2：会話・BGMをつける")]
    public bool _event2;
    bool _isFirst2;
    [SerializeField] AudioClip _bossBGM;

    [Header("Event3：戦闘開始")]
    bool _event3;
    bool _isFirst3;
    [SerializeField] GameObject _bossSlider;

    [Header("Event4：討伐")]
    bool _event4;

    [Header("End")]
    [SerializeField] AudioClip _endBGM;
    [SerializeField] GameObject _fadePanel;
    bool _endScene;
    bool _isFirstEnd;

    [Header("Camera")]
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _bossCamera;
    [SerializeField] GameObject _nearCamera;


    #endregion

    void Start()
    {
        GetComponents();
        Event1();
        _nearCamera.SetActive(true);
        _bossCamera.SetActive(false);
        _mainCamera.SetActive(false);
    }

    void GetComponents() //componentを取得してくる
    {
        _textController = _txtCtrl.GetComponent<TextController>();
        _textSkip = _txtCtrl.GetComponent<TextSkip>();
        _inputController = GetComponent<InputController>();
        _uiController = _uiCtrl.GetComponent<UIController>();
        GameObject audioObj = GameObject.Find("Audio");
        _audio = audioObj.GetComponent<AudioSource>();
        _scene = GetComponent<Scene>();
    }


    void Update()
    {

        if (_event1 && _textController._textcount == 1 && !_isFirst1)
        {
            Event1_2();
            _isFirst1 = true;
        }

        if (_textController._textcount == 5 && !_isFirst2)
        {
            Event2();
            _isFirst2 = true;
        }

        if (!_textController._textArea.activeSelf && _event3 && !_isFirst3)
        {
            Event3();
            _isFirst3 = true;
        }

        if (_event4)
        {
            Event4();
        }

        if (!_textController._textArea.activeSelf && _endScene && !_isFirstEnd)
        {
            EndScene();
            _isFirstEnd = true;
        }
    }

    void Event1()//会話のあとBGMを止める・BOSSを沸かせる
    {
        _uiController._authoritySkillGage.gameObject.SetActive(true);
        _inputController.PlayerStop();
        _textController.Main3();
        _textSkip.enabled = false;
        _event1 = true;
    }
    void Event1_2()
    {
        _audio.Stop();

        //ボスを沸かせる
        _bossPrefab.SetActive(true);
        Boss_Attack bossAttack = _bossPrefab.GetComponent<Boss_Attack>();
        bossAttack.enabled = false;

        //カメラ
        _nearCamera.SetActive(false);
        _bossCamera.SetActive(true);

    }
    void Event2() //会話・BGMをつける ストーリースキップはここからできるようにしたい
    {
        _audio.clip = _bossBGM;
        _audio.Play();
        _textSkip.enabled = true;
        _event3 = true;
    }

    void Event3()
    {
        //カメラ
        _bossCamera.SetActive(false);
        _mainCamera.SetActive(true);

        //UIを表示
        _bossSlider.SetActive(true);
        _authorityGage.SetActive(true);
        _uiController.Group1();
        _uiController.Group2();

        //行動制限解除
        _inputController.PlayerAwake();
        _inputController.AuthortySkill();
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
            EndScenePlay();
            _event4 = false;
        }
    }

    void EndScenePlay()
    {
        //行動制限・ UI非表示
        _inputController.PlayerStop();
        GameObject uiCanvas = GameObject.Find("UICanvas");
        uiCanvas.SetActive(false);

        _audio.clip = _endBGM;
        _audio.Play();

        //シナリオ再生
        _mainCamera.SetActive(false);
        _nearCamera.SetActive(true);
        _textController.Main3End();
        _endScene = true;
    }

    void EndScene()
    {
        _fadePanel.SetActive(true); //暗転アニメーション
        Invoke("EndingSwitch", 7);
    }

    void EndingSwitch()
    {
        _scene.SceneChange();
    }
}