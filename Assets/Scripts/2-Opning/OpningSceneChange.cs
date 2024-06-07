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

    void Start()
    {
        _fedeOut.SetActive(false);
        _audioObj = GameObject.Find("Audio");
    }

    public void TimeLag()
    {
        Invoke("Scene", 2); //2秒後にシーン遷移する。フェードアニメーションの時間と合わせる
        _fedeOut.SetActive(true);
        _moveObject.Play("TitleChange"); //流したいアニメーションファイルの名前に書き換える
    }

    public void Scene()
    {
        Destroy(_audioObj);
        SceneManager.LoadScene(_loadScene);
    }
}
