using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChange : MonoBehaviour
{

    [SerializeField] string _loadScene;
    [SerializeField] int _derayTime =2;
    [SerializeField] Animator _moveObject; //アニメーションをつけたオブジェクトをアタッチ
    public GameObject _fedeOut; //フェードアウト用のパネル
    public GameObject _audioObj;

    void Start()
    {
        _fedeOut.SetActive(false);
    }

    public void TimeLag()
    {
        Invoke("Scene", _derayTime); //2秒後にシーン遷移する。フェードアニメーションの時間と合わせる
        _fedeOut.SetActive(true);
        _moveObject.Play("TitleChange"); //流したいアニメーションファイルの名前に書き換える
        DontDestroyOnLoad(_audioObj); //画面遷移してもオブジェクトが壊れないようにする
    }

    public void Scene()
    {
        SceneManager.LoadScene(_loadScene);
    }

}