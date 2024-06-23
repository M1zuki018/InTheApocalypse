using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Slider : MonoBehaviour
{
    [SerializeField] Slider _bossSlider;
    GameObject _boss;
    EnemyController _bossEc;
    bool _isFirst;
    bool _isFirst2;

    //break用のGage差し替えを作る

    private void Awake()
    {
        _boss = GameObject.FindWithTag("Boss");
        _bossEc = _boss.GetComponent<EnemyController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SliderReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (_bossEc._danger)
        {
            if (!_isFirst)
            {
                GageChange();
                _isFirst = true;
                _isFirst2 = false;
            }
            BossDanger();
        }
        else
        {
            if (!_isFirst2)
            {
                SliderReset();
                _isFirst2 = true;
                _isFirst = false;
            }
        }
        BossHp();

        if(_boss == null)
        {
            Destroy(gameObject);
        }
    }

    void SliderReset() //HPをセットする
    {
        _bossSlider.maxValue = _bossEc._enemyMaxHp;
        _bossSlider.value = _bossEc._enemyHp;
    }

    void BossHp() //HP更新
    {
        _bossSlider.value = _bossEc._enemyHp;
    }

    void GageChange() //breakGageをセットする
    {
        _bossSlider.maxValue = _bossEc._breakMaxCount;
        _bossSlider.value = _bossEc._breakCount;
    }

    void BossDanger() //breakGage更新
    {
        _bossSlider.value = _bossEc._breakCount;
    }
}
