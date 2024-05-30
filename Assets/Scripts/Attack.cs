using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject _approachEnemy;
    bool _approach = false;

    private void Update()
    {
        PlayerAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enter OnTriggerEnter2D.");
            _approach = true;
            _approachEnemy = collision.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _approach = false ;
    }

    private void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1") && _approach)
        {
            Destroy(_approachEnemy.gameObject);
            Debug.Log("çUåÇ");
        }
    }
}
