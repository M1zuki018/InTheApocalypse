using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy_Attack : MonoBehaviour
{

    public static int _damage = 10;
    private int count = 0;
    public GameObject _attackArea;

    private void Start()
    {
        _attackArea.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("”½‰ž’†");
        count++;
        if (count % 100 == 0)
        {
            _attackArea.SetActive(true);

            if (collision.gameObject.tag == "Player") 
            {
                PlayerController._chara1HP = PlayerController._chara1HP - _damage;
            }
            
        }
        else
        {
            _attackArea.SetActive(false);
        }
    }
}