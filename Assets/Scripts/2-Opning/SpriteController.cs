using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;
    SpriteRenderer _sprite;

    int _spriteIndex;

    GameObject _sceneChanger;
    OpningSceneChange _sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        _sceneChanger = GameObject.Find("SceneChanger");
        _sceneChange = _sceneChanger.GetComponent<OpningSceneChange>();

        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _sprites[0];
        StartCoroutine("SpriteChange");
    }

    IEnumerator SpriteChange()
    {
        if (_spriteIndex == _sprites.Length)
        {
            _sceneChange.TimeLag();
            yield break;
        }
        _sprite.sprite = _sprites[_spriteIndex];

        yield return new WaitForSeconds(5.0f);

        _spriteIndex++; //画像を更新
        StartCoroutine("SpriteChange");
    }
}
