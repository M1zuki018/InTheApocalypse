using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRandom : MonoBehaviour
{

    public Sprite[] _spriteArray;    // インスペクターから割り当てる
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        var go = _spriteArray[Random.Range(0, _spriteArray.Length)];
        spriteRenderer.sprite = go;

    }
}
