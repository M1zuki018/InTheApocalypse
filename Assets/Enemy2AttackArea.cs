using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy2AttackArea : MonoBehaviour
{
    Enemy2Attack _enemy2Attack;

    private void Start()
    {
        _enemy2Attack = GetComponentInParent<Enemy2Attack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _enemy2Attack._playerAttack2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _enemy2Attack._playerAttack2 = false;
        }
    }
}
