using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider _hpSlider;
    [SerializeField] Slider _avoidSlider;
    [SerializeField] Slider _skill1Slider;
    [SerializeField] Slider _skill2Slider;
    [SerializeField] Slider _breakSlider;

    [SerializeField] GameObject _group1;
    [SerializeField] GameObject _group2;

    void Start()
    {
        SliderReset();
        _group1.SetActive(false);
        _group2.SetActive(false);
    }

    void Update()
    {
        SliderUpdate();
    }

    void SliderReset()　//スライダーの初期化
    {
        _hpSlider.value = PlayerController._chara1HP;
        _avoidSlider.value = PlayerController._avoidCoolTime;
        _skill1Slider.value = Player_Skill1._skillCoolTime1;
        _skill2Slider.value = Player_Skill2._skillCoolTime2;
        //_breakSlider.maxValue = _enemyMaxHp;
        //_breakSlider.value = _enemyHp;
    }

    void SliderUpdate() //スライダーの更新
    {
        _hpSlider.value = (float)PlayerController._chara1HP;
        _avoidSlider.value = (float)PlayerController._avoidCount;
        _skill1Slider.value = (float)Player_Skill1._skillTimerCount1;
        _skill2Slider.value = (float)Player_Skill2._skillTimerCount2;
        //_breakSlider.value = _enemyHp;
    }

    public void Group1() //HP、回避、スキルクールタイムのグループ
    {
        _group1.SetActive(true);
    }

    public void Group2() //MPバーのグループ
    {
        _group2.SetActive(true);
    }

}
