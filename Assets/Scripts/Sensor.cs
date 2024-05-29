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
        //ínñ Ç…êGÇÍÇΩÇÁtrue
        if (collision.gameObject.tag == "Ground")
        {
            _touchGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //ínñ Ç©ÇÁó£ÇÍÇΩéûÇ…false
        _touchGround = false;
    }
}
