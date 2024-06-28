using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Slider : MonoBehaviour
{
    [SerializeField] Slider _bossSlider;
    GameObject _boss;
    EnemyController _bossEc;

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
        if(_boss == null)
        {
            Destroy(gameObject);
        }
        BossHp();
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
}
