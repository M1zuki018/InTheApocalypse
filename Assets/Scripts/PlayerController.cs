using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; // Rigidbody2Dコンポーネントへの参照
    private float xSpeed; // X方向移動速度
    public CameraController cameraController; // カメラ制御クラス

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        // カメラ初期位置
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();

        // カメラに自身の座標を渡す
        cameraController.SetPosition(transform.position);
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.D)) // 右方向の移動入力
        {
            xSpeed = 6.0f;
        }
        else if (Input.GetKey(KeyCode.A)) // 左方向の移動入力
        {
            xSpeed = -6.0f;
        }
        else
        {
            xSpeed = 0.0f; // 入力なし X方向の移動を停止
        }
    }

    private void PlayerJump()
    {
        // ジャンプ操作
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ジャンプ力を計算
            float jumpPower = 10.0f;
            // ジャンプ力を適用
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        }
    }
    
    // FixedUpdate（一定時間ごとに1度ずつ実行・物理演算用）
    private void FixedUpdate()
    {
        // 移動速度ベクトルを現在値から取得
        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = xSpeed; // X方向の速度を入力から決定

        // 計算した移動速度ベクトルをRigidbody2Dに反映
        rigidbody2D.velocity = velocity;
    }
}
