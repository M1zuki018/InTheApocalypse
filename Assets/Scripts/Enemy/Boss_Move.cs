using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tag「Player」と一定の距離をとって空中移動
/// 壁まで行くと反対側に瞬間移動する
/// 停止する
/// </summary>
public class Boss_Move : MonoBehaviour
{
    GameObject _player;
    Boss_Attack _attack;

    Vector3 _initialPosition; //初期位置

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
    
    void Movement() //プレイヤーと一定の距離をとって移動（高さも変わる）
    {
        transform.position = _playerTf.position + _offset;
    }

    void HorizontarMovement() //プレイヤーと一定の距離をとって移動
    {
        transform.position = new Vector3(_playerTf.position.x + _offset.x, 0, 0);
    }
}
