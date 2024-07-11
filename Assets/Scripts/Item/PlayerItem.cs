using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    List<ItemBase> _itemList = new List<ItemBase>();

    // Update is called once per frame
    void Update()
    {
        // �A�C�e�����g��
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (_itemList.Count > 0)
            {
                // ���X�g�̐擪�ɂ���A�C�e�����g���āA�j������
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
