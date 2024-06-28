using UnityEngine;
using UnityEngine.UI;

public class Boss_BreakSlider : MonoBehaviour
{
    [SerializeField] Slider _bossSlider;
    GameObject _boss;
    EnemyController _bossEc;

    //break�p��Gage�����ւ������

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

    void GageChange() //breakGage���Z�b�g����
    {
        _bossSlider.maxValue = _bossEc._breakMaxCount;
        _bossSlider.value = _bossEc._breakCount;
    }

    void BossDanger() //breakGage�X�V
    {
        _bossSlider.value = _bossEc._breakCount;
    }
}

