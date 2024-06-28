using System.Collections;
using UnityEngine;

public class Main2_Movie : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Vector3 _position;

    bool _isFirst;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !_isFirst)
        {
            StartCoroutine(Spone());
            _isFirst = true;
        }
    }

    IEnumerator Spone()
    {
        Instantiate(_prefab, _position , Quaternion.identity);

        yield return new WaitForSeconds(4);

        StartCoroutine(Spone());
    }
}
