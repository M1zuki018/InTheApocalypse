using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ①自分の元から一定間隔で雑魚を産み落とす感じ×4
/// ②赤枠→１秒後にそこに敵が流れてくる×横方向２回
/// ③縦方向に5本同時×1回
/// ①～③を2回繰り返した後
/// ④全体攻撃っぽいやつ1回
/// </summary>
public class Boss_Attack : MonoBehaviour
{
    EnemyController _enemyController;
    [SerializeField] Transform _point;

    [SerializeField] GameObject _underling;
    [SerializeField] int _sponeInterval = 4;
    int _sponeCount;

    public bool _move;
    public bool _horizontarMove;

    [SerializeField] GameObject _attack2Zone;
    [SerializeField] GameObject _attack2;
    [SerializeField] Transform[] _attackHeight;
    int _attackCount;

    [SerializeField] GameObject _attack3Zone;
    [SerializeField] GameObject _attack3;
    int _turn;

    bool _isFirst;
    float _time;
    [SerializeField] UnityEngine.Vector3 _generationArea;
    [SerializeField] float _dangerAttackLimit;

    bool _isFirstBreakUpdate;
    [SerializeField] int _breakTime;
    [SerializeField] Transform _breakPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        _enemyController = GetComponent<EnemyController>();
        Initialization();
        StartCoroutine("Attack1Coroutine");
        _move = true;
    }

    void Initialization()
    {
        _attack2Zone.SetActive(false);
        _attack2.SetActive(false);
        _attack3Zone.SetActive(false);
        _attack3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyController._danger)
        {
            Attack4();
        }


        if(_enemyController._break && !_isFirstBreakUpdate)
        {
            StartCoroutine("BossBreak");
            _isFirstBreakUpdate = true;
        }
    }

    #region 攻撃パターン① 自分の元から一定間隔で雑魚を産み落とす×4
    void Attack1()
    {
        UnityEngine.Vector3 vector3 = transform.position;
        Instantiate(_underling, vector3, UnityEngine.Quaternion.identity);
    }

    IEnumerator Attack1Coroutine()
    {
        _sponeCount++;
        //Debug.Log(_sponeCount);

        if (_sponeCount >= 5)
        {
            StartCoroutine("Attack2Coroutine");
            _move = false;
            _sponeCount = 0;
            yield break;
        }

            Attack1();

            yield return new WaitForSeconds(_sponeInterval);

        StartCoroutine("Attack1Coroutine");
    }
    #endregion

    #region 攻撃パターン② 赤枠→１秒後にそこに敵が流れてくる×横方向２回
    IEnumerator Attack2Coroutine()
    {
        //Debug.Log("攻撃②スタート");
        _horizontarMove = true;


        //危険エリアを表示
        _attack2Zone.transform.position = _attackHeight[_attackCount].position;
        _attack2Zone.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        //危険エリアを非表示
        _attack2Zone.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        //ダメージエリアを生成
        _attack2.transform.position = _attackHeight[_attackCount].position;
        _attack2.SetActive(true);

        yield return new WaitForSeconds(2);
        _attack2.SetActive(false);
        _attackCount++;

        yield return new WaitForSeconds(0.5f);

        if (_attackCount == 2)
        {
            StartCoroutine("Attack3Coroutine");
            _attackCount = 0;
            _horizontarMove= false;
            //Debug.Log("_attackCount:" + _attackCount);
            yield break;
        }
        else if (_attackCount == 1)
        {
            StartCoroutine("Attack2Coroutine");
        }
    }
    #endregion

    #region 攻撃パターン③ 縦方向に5本同時×1回
    IEnumerator Attack3Coroutine()
    {
        gameObject.transform.position = _point.position;

        yield return new WaitForSeconds(4f);

        //危険エリアを表示
        _attack3Zone.SetActive(true);

        yield return new WaitForSeconds(3f);

        //危険エリアを非表示
        _attack3Zone.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        //ダメージエリアを生成
        _attack3.SetActive(true);

        yield return new WaitForSeconds(1);

        _attack3.SetActive(false);
        _turn++;

        if (_turn == 1)
        {
            StartCoroutine("Attack1Coroutine");
            _move = true;
            yield break;
        }
        else
        {
            _enemyController._danger = true;
            _turn = 0;
            yield break;
        }
    }
    #endregion

    //攻撃パターン④
    //Update関数内で、「_danger」がtrueの時に呼ばれる
    void Attack4()
    {
        _time += Time.deltaTime;
        if (!_isFirst)
        {
            transform.position = _breakPoint.position;
            StartCoroutine("Generation");
            _isFirst = true;
        }
        
        //breakテスト用
        if (Input.GetKeyDown(KeyCode.G))
        {
            _enemyController._break = true;
        }
        
        if (_enemyController._break)
        {
            _enemyController._danger = false; //Gageを時間内に削りきれたらブレイク
            _isFirst = false;
            return;
        }
        else if (_time >= _dangerAttackLimit && _enemyController._break == false)
        {
            PlayerController._chara1HP -= 90;
            _enemyController._danger = false;
            StartCoroutine("Attack1Coroutine"); //攻撃の最初に戻る
            _move = true;
            _isFirst = false;
        }
    }

    IEnumerator Generation() //ぽこぽこ手下を沸かす
    {
        if (_time >= _dangerAttackLimit || _enemyController._break)
        {
            _time = 0;
            yield break;
        }
        Instantiate(_underling, _generationArea, UnityEngine.Quaternion.identity);

        yield return new WaitForSeconds(6);

        StartCoroutine("Generation");

    }

    IEnumerator BossBreak()
    {
        yield return new WaitForSeconds(_breakTime);

        StartCoroutine("Attack1Coroutine");
        _enemyController._break = false;
        transform.position = _point.position;
        _move = true;
        _isFirstBreakUpdate = false;

        yield break;
    }
}
