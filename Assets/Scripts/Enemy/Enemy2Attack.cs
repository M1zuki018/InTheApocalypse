using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : MonoBehaviour
{
    public bool _playerAttack2;
    int _damage = 20;
    [SerializeField] int _wait = 6;
    GameObject _circle;

    //É_ÉÅÅ[ÉWÇó^Ç¶ÇΩéû
    GameObject _playerObj;
    SpriteRenderer _playerSpriteRenderer;
    GameObject _seObj;
    Main1_SEController _seController;

    private void Start()
    {
        _playerObj = GameObject.FindWithTag("Player");
        _seObj = GameObject.Find("SE");
        _playerSpriteRenderer = _playerObj.GetComponent<SpriteRenderer>();
        _seController = _seObj.GetComponent<Main1_SEController>();

        _circle = transform.GetChild(2).gameObject;

        _circle.SetActive(false);

        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(_wait);

        if (_playerAttack2)
        {
            //åxçêÅ®çUåÇ

            _circle.SetActive(true);

            yield return new WaitForSeconds(3);

            _circle.SetActive(false);
            PlayerController._chara1HP = PlayerController._chara1HP - _damage;
            _playerSpriteRenderer.color = new Color(1, 0.2f, 0.2f);
            _seController.Dameged();

            yield return new WaitForSeconds(0.05f);

            _playerSpriteRenderer.color = Color.white;

            yield return new WaitForSeconds(0.04f);

            _playerSpriteRenderer.color = new Color(1, 0.2f, 0.2f);

            yield return new WaitForSeconds(0.07f);

            _playerSpriteRenderer.color = Color.white;
        }

        StartCoroutine(AttackCoroutine());
    }
}

