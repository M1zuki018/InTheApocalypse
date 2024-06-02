using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Search : MonoBehaviour
{
    Transform _playerTr;
    Transform _enemyTr;
    GameObject _playerObj;
    public GameObject _enemyObj;
    [SerializeField] float _speed = 2;

    bool _search;

    private void Start()
    {
        _playerObj = GameObject.Find("Player");
        _playerTr = _playerObj.GetComponent<Transform>();
        _enemyTr = _enemyObj.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")//プレイヤーがセンサー内に入ってきたら
        {
            _search = true;
            Debug.Log("反応中");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//プレイヤーがセンサー内に入ってきたら
        {
            _search = false;
        }
    }

    void Update()
    {
        if(_search)
        {
            //プレイヤーに向けて近づく
            _enemyObj.transform.position = Vector2.MoveTowards(_enemyTr.transform.position, new Vector2(_playerTr.position.x, _playerTr.position.y), _speed * Time.deltaTime);
        }
    }
}
