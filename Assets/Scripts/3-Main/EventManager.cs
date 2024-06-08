using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject _txtCtrl;
    TextController _textController;

    [Header("Event1：スタート時のイベント")]
    public bool _event1;
    [SerializeField] GameObject _playerObj;
    [SerializeField] int _stopSeconds;

    [Header("Event2：敵と遭遇")]
    bool _isFirst2;
    public bool _event2;
    //敵をスポーンさせる
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Vector3 _sponePosition;
    //カメラを動かす

    [Header("Event3：操作のチュートリアル")]
    public bool _event3;
    //パネルを表示する
    //終わったら行動できるようにする

    [Header("Event4：敵が全滅したら会話を開始")]
    public bool _event4;

    [Header("Event5：バトル②")]
    public bool _event5;
    //敵を沸かせる

    [Header("Event6：バトル③")]
    public bool _event6;
    //敵を沸かせる

    // Start is called before the first frame update
    void Start()
    {
        _textController = _txtCtrl.GetComponent<TextController>();

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
    }

    //最初は動けないようにする
    IEnumerator Event1()
    {
        PlayerController controller = _playerObj.GetComponent<PlayerController>();
        controller.enabled = false; //プレイヤーコントローラーを無効化
        
        yield return new WaitForSeconds(_stopSeconds);
        
        controller.enabled = true;
        
        yield break;
    }

    public void Event2()
    {
        Debug.Log("Event2 start");
        _textController.Event2Story();
        Instantiate(_enemyPrefab, _sponePosition, Quaternion.identity);
        StartCoroutine("Event2Coroutine");
    }

    IEnumerator Event2Coroutine()
    {

        PlayerController controller = _playerObj.GetComponent<PlayerController>();
        controller.enabled = false; //プレイヤーコントローラーを無効化

        EnemyController enemyController = _enemyPrefab.GetComponent<EnemyController>();
        enemyController.enabled = false;

        yield return new WaitForSeconds(10);

        controller.enabled = true;
        enemyController.enabled = true;
        Destroy(GameObject.Find("Event2"));
        _event3 = true;

        yield break;
    }

}
