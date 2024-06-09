using UnityEngine;

public class SEController : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClips;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region TitleシーンSE

    public void GameStart()
    {
        _audioSource.PlayOneShot(_audioClips[0]);
    }

    public void ButtonDown()
    {
        _audioSource.PlayOneShot(_audioClips[1]);
    }

    #endregion

    public void Opning()
    {
        _audioSource.PlayOneShot(_audioClips[0]);
    }
}
