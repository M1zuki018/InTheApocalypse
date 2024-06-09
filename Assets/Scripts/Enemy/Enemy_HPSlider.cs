using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HPSlider : MonoBehaviour
{

    //プレイヤーと一番近い敵
    private float _shortestDistance;
    GameObject _nearestEnemy;
    public GameObject _player;
    public Slider _enemyHpSlider;
    GameObject _sliderBackground;
    GameObject _sliderFillArea;

    private void Start()
    {
        _sliderBackground = transform.GetChild(0).gameObject;
        _sliderFillArea = transform.GetChild(1).gameObject;

    }

    void Update()
    {
        GetNearEnemy();
        
        if (_nearestEnemy == null)
        {
            _sliderBackground.SetActive(false);
            _sliderFillArea.SetActive(false);
        }
        else
        {
            _sliderBackground.SetActive(true);
            _sliderFillArea.SetActive(true);
        }

        GetDate();
    }


    void GetNearEnemy()
    {
        _shortestDistance = 50f; // 基準距離
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); //エネミーを取得
        foreach (GameObject enemy in enemys)
        {
            float distance = Vector2.Distance(_player.transform.position, enemy.transform.position);
            if (distance < _shortestDistance)
            {
                _shortestDistance = distance; // 最短距離の更新
                _nearestEnemy = enemy;
            }
        }
    }

    void GetDate() //一番近い敵のHPを取得してHPバーに反映する
    {
        if (_nearestEnemy)
        {
            _nearestEnemy.TryGetComponent(out EnemyController enemyHp);
            _enemyHpSlider.maxValue = enemyHp._enemyMaxHp;
            _enemyHpSlider.value = enemyHp._enemyHp;
        }
    }
}
