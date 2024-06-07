using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpningSceneChange : MonoBehaviour
{
    [SerializeField] private string _loadScene;
    [SerializeField] Animator _moveObject; //�A�j���[�V�����������I�u�W�F�N�g���A�^�b�`
    public GameObject _fedeOut; //�t�F�[�h�A�E�g�p�̃p�l��
    GameObject _audioObj;

    void Start()
    {
        _fedeOut.SetActive(false);
        _audioObj = GameObject.Find("Audio");
    }

    public void TimeLag()
    {
        Invoke("Scene", 2); //2�b��ɃV�[���J�ڂ���B�t�F�[�h�A�j���[�V�����̎��Ԃƍ��킹��
        _fedeOut.SetActive(true);
        _moveObject.Play("TitleChange"); //���������A�j���[�V�����t�@�C���̖��O�ɏ���������
    }

    public void Scene()
    {
        Destroy(_audioObj);
        SceneManager.LoadScene(_loadScene);
    }
}
