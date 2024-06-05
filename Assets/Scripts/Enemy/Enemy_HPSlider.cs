using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HPSlider : MonoBehaviour
{

    //�v���C���[�ƈ�ԋ߂��G
    private float _shortestDistance;
    private GameObject _nearestEnemy;
    public GameObject _player;
    public Slider _enemyHpSlider;

    void Update()
    {
        GetNearEnemy();
        
        if (_nearestEnemy == null)
        {
            _enemyHpSlider.gameObject.SetActive(false);
        }

        GetDate();
    }


    void GetNearEnemy()
    {
        _shortestDistance = 50f; // �����
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); //�G�l�~�[���擾
        foreach (GameObject enemy in enemys)
        {
            float distance = Vector2.Distance(_player.transform.position, enemy.transform.position);
            if (distance < _shortestDistance)
            {
                _shortestDistance = distance; // �ŒZ�����̍X�V
                _nearestEnemy = enemy;
            }
        }
    }

    void GetDate() //��ԋ߂��G��HP���擾����HP�o�[�ɔ��f����
    {
        if (_nearestEnemy)
        {
            _nearestEnemy.TryGetComponent(out EnemyController enemyHp);
            _enemyHpSlider.maxValue = enemyHp._enemyMaxHp;
            _enemyHpSlider.value = enemyHp._enemyHp;
        }
    }
}
