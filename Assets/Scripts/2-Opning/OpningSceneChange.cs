using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpningSceneChange : MonoBehaviour
{
    [SerializeField] private string _loadScene;
    [SerializeField] Animator _moveObject; //アニメーションをつけたオブジェクトをアタッチ
    public GameObject _fedeOut; //フェードアウト用のパネル
    GameObject _audioObj;
    AudioSource _audioSource;

    void Start()
    {
        _fedeOut.SetActive(false);
        _audioObj = GameObject.Find("Audio");
        _audioSource = _audioObj.GetComponent<AudioSource>();
    }

    public void TimeLag()
    {
        Invoke("Scene", 5); //2秒後にシーン遷移する。フェードアニメーションの時間と合わせる
        if (_audioSource != null)
        {
            StartCoroutine("VolumeDown"); //音量をだんだんさげる
        }
        _fedeOut.SetActive(true);
        _moveObject.Play("OpningChange"); //流したいアニメーションファイルの名前に書き換える
    }

    IEnumerator VolumeDown()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Scene()
    {
        Destroy(_audioObj);
        SceneManager.LoadScene(_loadScene);
    }
}
