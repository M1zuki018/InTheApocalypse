using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tag�uPlayer�v�ƈ��̋������Ƃ��ċ󒆈ړ�
/// �ǂ܂ōs���Ɣ��Α��ɏu�Ԉړ�����
/// ��~����
/// </summary>
public class Boss_Move : MonoBehaviour
{
    GameObject _player;
    Boss_Attack _attack;

    Vector3 _initialPosition; //�����ʒu

    Transform _playerTf;
    public Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _playerTf = _player.GetComponent<Transform>();
        _attack = GetComponent<Boss_Attack>();
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_attack._move)
        {
           Movement();
        }
        else if (_attack._horizontarMove)
        {
            HorizontarMovement();
        }
        
    }
    
    void Movement() //�v���C���[�ƈ��̋������Ƃ��Ĉړ��i�������ς��j
    {
        transform.position = _playerTf.position + _offset;
    }

    void HorizontarMovement() //�v���C���[�ƈ��̋������Ƃ��Ĉړ�
    {
        transform.position = new Vector3(_playerTf.position.x + _offset.x, 0, 0);
    }
}
