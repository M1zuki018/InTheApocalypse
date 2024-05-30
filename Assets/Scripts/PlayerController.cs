﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _movePower = 5f; //左右移動
    [SerializeField] float _jumpPower = 15f; //ジャンプ
    [SerializeField] bool _flipX = false; //左右反転させるかどうか

    Rigidbody2D _rb = default;

    float m_h; //水平方向の入力値

    Vector3 _initialPosition; //初期位置

    int _jampCount; //ジャンプの回数

    public CameraController _cameraController; //カメラコントローラー

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPosition = this.transform.position; //
        
        _cameraController.SetPosition(transform.position); //
    }

    // Update is called once per frame
    void Update()
    {

        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        PlayerJump();
        PlayerReset();
        PlayerAttack();
        PlayerAvoid();

        // カメラをプレイヤーにセットする
        _cameraController.SetPosition(transform.position);


        // 設定に応じて左右を反転させる
        if (_flipX)
        {
            FlipX(m_h);
        }
    }

    private void PlayerJump()
    {
        //Debug.Log(Sensor._touchGround); 接地判定デバッグ用
        if (Sensor._touchGround) //地面に触れたらカウントをリセットする
        {
            _jampCount = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _jampCount++; //スペースを押された回数をカウント
            //Debug.Log(_jampCount); 2段ジャンプデバッグ用
            if (_jampCount < 2)
            {
                _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void PlayerReset()
    {
        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = _initialPosition;
        }
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        _rb.AddForce(Vector2.right * m_h * _movePower, ForceMode2D.Force);
    }

    void FlipX(float horizontal)
    {
        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    void PlayerAttack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("攻撃");
        }
    }

    void PlayerAvoid()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("回避");
        }
    }
}
