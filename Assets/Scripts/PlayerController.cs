using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _movePower = 5f; //左右移動
    [SerializeField] float _jumpPower = 15f; //ジャンプ
    [SerializeField] float _avoidPower = 15f; //回避の距離
    [SerializeField] bool _flipX = false; //左右反転させるかどうか

    Rigidbody2D _rb = default;

    float m_h; //水平方向の入力値

    Vector3 _initialPosition; //初期位置

    int _jampCount; //ジャンプの回数

    //プレイヤーの向きを取得するフラグ
    public static bool _facingLeft;
    public static bool _facingRight;

    //プレイヤーの数値系
    int _chara1MaxHP = 100;
    public static int _chara1HP;

    //MP関係
    int _maxMP = 150;
    public static int _mp;
    public static bool _mpNotEnough;
    public GameObject _notEnoughMpObj; //MPが足りない時に出すテキスト
    int _mpPlus = 0;

    //回避
    public static int _avoidCount = 1000;
    public static int _avoidCoolTime = 1000;

    GameObject _skill1Area;
    GameObject _magic1;
    GameObject _magic2;
    int _count;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _initialPosition = this.transform.position; //初期位置にセット

        //HP・MPの初期化
        _chara1HP = _chara1MaxHP;
        _mp = _maxMP;

        _notEnoughMpObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _avoidCount++;

        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        //ジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }

        //回避
        if (Input.GetButtonDown("Fire2"))
        {
            PlayerAvoid();
        }

        //Eキーを押したときの挙動
        if (Input.GetKeyDown(KeyCode.E) && _count % 2 == 1)
        {
            if (_skill1Area == null)
            {
                _magic1 = GameObject.Find("Magic1");
                _magic2 = GameObject.Find("Magic2");
            }

            if (_magic1.activeSelf)
            {
                PlayerMagic();
            }
        }

        //Rキーを押したときの処理
        if (Input.GetKeyDown(KeyCode.R) && _count % 2 == 1)
        {
            if (_magic2.activeSelf)
            {
                PlayerMagic();
            }
        }
        
        AuthoritySkill(); //権限
        MagicPoint(); //MP自動回復


        /*
        //下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = _initialPosition;
        }
        */

        // 設定に応じて左右を反転させる
        if (_flipX)
        {
            FlipX(m_h);
        }
    }

    private void PlayerJump()
    {
        
        _jampCount++; //スペースを押された回数をカウント
        
        if (_jampCount < 2)
        {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);

        }
        if (Player_Sensor._touchGround) //地面に触れたらカウントをリセットする
        {
            _jampCount = 0;
        }
    }

    private void FixedUpdate() // 力を加えるのは FixedUpdate で行う
    {
        _rb.AddForce(Vector2.right * m_h * _movePower, ForceMode2D.Force);
    }

    void FlipX(float horizontal) //反転
    {
        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            _facingRight = true;
            _facingLeft = false;
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            _facingLeft = true;
            _facingRight = false;
        }
    }

    void PlayerAvoid() //回避。キーが押されたら呼ばれる
    {
        if (_avoidCount>= _avoidCoolTime) //回避のクールタイム
        {
            _avoidCount = 0;

            if (_facingLeft == true)
            {
                _rb.AddForce(Vector2.right * _avoidPower, ForceMode2D.Impulse);
            }
            else
            {
                _rb.AddForce(Vector2.left * _avoidPower, ForceMode2D.Impulse);
            }
            //Debug.Log("回避");
        }
    }
 
    void PlayerMagic() //魔法発動時の処理
    {
        Debug.Log(_mpNotEnough);
        if (_mpNotEnough == true)
        {
            _notEnoughMpObj.SetActive(true);
            Invoke("MpObjHidden", 3);
        }
    }

    void MpObjHidden()
    {
        _notEnoughMpObj.SetActive(false);
    }

    void AuthoritySkill() //権限解放
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("権限解放");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //ノックバック
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _rb.AddForce(Vector2.left * 3.0f, ForceMode2D.Impulse);
            Debug.Log("敵に触れた");
        }
    }

    void MagicPoint() //MPの自動回復
    {
        _mpPlus++;

        if(_mpPlus % 200 == 0)
        {
            _mp++;
        }
    }

}
