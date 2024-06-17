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
    AudioSource _audioSource;

    void Start()
    {
        _fedeOut.SetActive(false);
        _audioObj = GameObject.Find("Audio");
        _audioSource = _audioObj.GetComponent<AudioSource>();
    }

    public void TimeLag()
    {
        Invoke("Scene", 5); //2�b��ɃV�[���J�ڂ���B�t�F�[�h�A�j���[�V�����̎��Ԃƍ��킹��
        if (_audioSource != null)
        {
            StartCoroutine("VolumeDown"); //���ʂ����񂾂񂳂���
        }
        _fedeOut.SetActive(true);
        _moveObject.Play("OpningChange"); //���������A�j���[�V�����t�@�C���̖��O�ɏ���������
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
