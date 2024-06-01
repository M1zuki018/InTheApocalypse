using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Heel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController._chara1HP = PlayerController._chara1HP + 10;
            Destroy(gameObject);
        }
    }
}
