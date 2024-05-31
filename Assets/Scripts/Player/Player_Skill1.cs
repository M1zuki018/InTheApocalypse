using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill1 : MonoBehaviour
{
    GameObject _approachEnemy;
    bool _approach = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerSkill1();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerSkill2();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enter OnTriggerEnter2D.");
            _approach = true;
            _approachEnemy = collision.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _approach = false;
    }

    private void PlayerSkill1()
    {
        if (_approach)
        {
            Destroy(_approachEnemy.gameObject);
            Debug.Log("スキル1");
        }
    }

    private void PlayerSkill2()
    {
        if (_approach)
        {
            Destroy(_approachEnemy.gameObject);
            Debug.Log("スキル2");
        }
    }
}
