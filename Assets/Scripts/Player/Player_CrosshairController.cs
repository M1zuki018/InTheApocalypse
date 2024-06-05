using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CrosshairController : MonoBehaviour
{

    void Start()
    {
        // マウスカーソルを消す
        //Cursor.visible = false;
    }

    void Update()
    {
        if (PlayerController._magicMode)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;    // Z 座標がカメラと同じになっているので、リセットする
            this.transform.position = mousePosition;
        }
    }
}
