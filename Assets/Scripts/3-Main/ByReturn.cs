using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByReturn : MonoBehaviour
{
    [SerializeField] GameObject _stairs;
    BoxCollider2D _stairsCollider;
    SpriteRenderer _stairsSpriteRenderer;

    void Start()
    {
        _stairsCollider = _stairs.GetComponent<BoxCollider2D>();
        _stairsSpriteRenderer = _stairs.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _stairsCollider.enabled = false;
            _stairsSpriteRenderer.color = new Color(0,0,0,0.5f);
        }
    }
}
