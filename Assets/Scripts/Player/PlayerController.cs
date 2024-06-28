using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動系
    [SerializeField] float _movePower = 13f; //左右移動
    [SerializeField] float _jumpPower = 8f; //ジャンプ
    [SerializeField] float _avoidPower = 5f; //回避の距離
    [SerializeField] bool _flipX = false; //左右反転させるかどうか

    Rigidbody2D _rb = default;

    float m_h; //水平方向の入力値

    Vector3 _initialPosition; //初期位置

    int _jampCount; //ジャンプの回数

    //プレイヤーの向きを取得するフラグ
    public static bool _facingLeft;
    public static bool _facingRight;

    //HP
    public static int _chara1MaxHp = 250; //250
    public static int _chara1HP;

    //回避
    public static int _avoidCount = 1000;
    public static int _avoidCoolTime = 1000;

    GameObject _mpController;
    EnvironmentMp mp;

    GameObject _skill1Area;
    GameObject _magic1;
    GameObject _magic2;
    int _count;
    public static bool _magicMode;

    GameObject _seObj;
    Main1_SEController _seController;

    [SerializeField] GameObject _gameOverPanel;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _seObj = GameObject.Find("SE");
        _seController = _seObj.GetComponent<Main1_SEController>();

        _initialPosition = this.transform.position; //初期位置にセット

        //HPの初期化
        _chara1HP = _chara1MaxHp;

        _mpController = GameObject.Find("MpObj");
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            _count++;
            _seController.StateChange();

            if (_count % 2 == 1)
            {
                _magicMode = true;
            }
            else
            {
                _magicMode = false;
            }
        }

        //Eキーを押したときの挙動
        if (Input.GetKeyDown(KeyCode.E) && _magicMode)
        {
            if (_skill1Area == null)
            {
                _magic1 = GameObject.Find("Magic1");
                _magic2 = GameObject.Find("Magic2");
            }

            if (_magic1.activeSelf)
            {
                _mpController.TryGetComponent(out EnvironmentMp mp);
                mp.PlayerMagic();
            }
        }

        //Rキーを押したときの処理
        if (Input.GetKeyDown(KeyCode.R) && _magicMode)
        {
            if (_magic2.activeSelf)
            {
                _mpController.TryGetComponent(out EnvironmentMp mp);
                mp.PlayerMagic();
            }
        }

        // 設定に応じて左右を反転させる
        if (_flipX)
        {
            FlipX(m_h);
        }

        GameOver();
    }

    private void PlayerJump()
    {

        _jampCount++; //スペースを押された回数をカウント

        if (_jampCount < 2)
        {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _seController.Jump();

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
        if (_avoidCount >= _avoidCoolTime) //回避のクールタイム
        {
            _avoidCount = 0;
            _seController.Avoid();

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

    private void OnCollisionEnter2D(Collision2D collision) //ノックバック
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _rb.AddForce(Vector2.left * 3.0f, ForceMode2D.Impulse);
            //Debug.Log("敵に触れた");
        }
    }

    void GameOver()
    {
        if (_chara1HP <= 0)
        {
            _gameOverPanel.SetActive(true);
            GameObject audio = GameObject.Find("Audio");
            Destroy(audio);
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemys)
            {
                enemy.SetActive(false);
            }
            //ボス用の処理も書く
        }
    }
}
