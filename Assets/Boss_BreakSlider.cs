using UnityEngine;
using UnityEngine.UI;

public class Boss_BreakSlider : MonoBehaviour
{
    [SerializeField] Slider _bossSlider;
    GameObject _boss;
    EnemyController _bossEc;

    //break用のGage差し替えを作る

    private void Awake()
    {
        _boss = GameObject.FindWithTag("Boss");
        _bossEc = _boss.GetComponent<EnemyController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GageChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (_boss == null)
        {
            Destroy(gameObject);
        }
        BossDanger();
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

