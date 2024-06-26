using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main1_SEController : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClip;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        _audioSource.PlayOneShot(_audioClip[0]);
    }

    public void Jump()
    {
        _audioSource.PlayOneShot(_audioClip[1]);
    }
    public void Avoid()
    {
        _audioSource.PlayOneShot(_audioClip[2]);
    }
    public void Skill1()
    {
        _audioSource.PlayOneShot(_audioClip[3]);
    }
    public void Skill2()
    {
        _audioSource.PlayOneShot(_audioClip[4]);

    }
    public void Magic1()
    {
        _audioSource.PlayOneShot(_audioClip[5]);

    }
    public void Magic2()
    {
        _audioSource.PlayOneShot(_audioClip[6]);

    }
    public void AuthoritySkill()
    {
        _audioSource.PlayOneShot(_audioClip[7]);

    }
    public void Damage()
    {
        _audioSource.PlayOneShot(_audioClip[8]);

    }
    public void StateChange()
    {
        _audioSource.PlayOneShot(_audioClip[9]);

    }

    public void Dameged()
    {
        _audioSource.PlayOneShot(_audioClip[10]);
    }
}