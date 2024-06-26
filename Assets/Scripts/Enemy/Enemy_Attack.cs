using System.Collections;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    bool _player;
    public static int _damage = 10;
    [SerializeField] int _wait = 5;

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

        StartCoroutine(AttackCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player = false;
        }
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(_wait);

        if (_player)
        {
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