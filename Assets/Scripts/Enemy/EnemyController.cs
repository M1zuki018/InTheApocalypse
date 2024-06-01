using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int _enemyHp;
    public Slider _enemyHpSlider;
    public GameObject _enemyHpSliderObj;

    // Start is called before the first frame update
    void Start()
    {
        _enemyHpSlider.value = _enemyHp;
    }

    // Update is called once per frame
    void Update()
    {
        _enemyHpSlider.value = (float)_enemyHp;
    }

    private void OnDestroy()
    {
        Destroy(_enemyHpSliderObj);
    }
}
