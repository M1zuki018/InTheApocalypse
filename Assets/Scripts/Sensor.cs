using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public static bool _touchGround;

    private void Update()
    {
        //Debug.Log(_touchGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�n�ʂɐG�ꂽ��true
        if (collision.gameObject.tag == "Ground")
        {
            _touchGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //�n�ʂ��痣�ꂽ����false
        _touchGround = false;
    }
}
