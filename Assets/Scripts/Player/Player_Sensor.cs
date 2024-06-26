using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sensor : MonoBehaviour
{
    public static bool _touchGround;

    private void Update()
    {
        Debug.Log(_touchGround);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _touchGround = true;
        }
        else
        {
            _touchGround = false;
        }
    }
}
