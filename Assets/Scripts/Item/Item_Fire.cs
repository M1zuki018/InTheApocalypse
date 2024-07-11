using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Fire : ItemBase
{
    public override void Activate()
    {
        PlayerController._chara1HP = PlayerController._chara1HP - 30;
    }
}
