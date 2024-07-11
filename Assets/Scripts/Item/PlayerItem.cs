using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    List<ItemBase> _itemList = new List<ItemBase>();

    // Update is called once per frame
    void Update()
    {
        // アイテムを使う
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (_itemList.Count > 0)
            {
                // リストの先頭にあるアイテムを使って、破棄する
                ItemBase item = _itemList[0];
                _itemList.RemoveAt(0);
                item.Activate();
                Destroy(item.gameObject);
            }
        }
    }

    public void GetItem(ItemBase item)
    {
        _itemList.Add(item);
    }
}
