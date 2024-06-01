using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _hpSlider;
    public Slider _mpSlider;
    public Slider _avoidSlider;
    public Slider _skill1Slider;
    public Slider _skill2Slider;

    // Start is called before the first frame update
    void Start()
    {
        _hpSlider.value = PlayerController._chara1HP;
        _mpSlider.value = PlayerController._mp;
        _avoidSlider.value = PlayerController._avoidCoolTime;
        _skill1Slider.value = Player_Skill1._skillCoolTime1;
        _skill2Slider.value = Player_Skill2._skillCoolTime2;
    }

    // Update is called once per frame
    void Update()
    {
        _hpSlider.value = (float)PlayerController._chara1HP;
        _mpSlider.value = (float)PlayerController._mp;
        _avoidSlider.value = (float)PlayerController._avoidCount;
        _skill1Slider.value = (float)Player_Skill1._skillCount1;
        _skill2Slider.value = (float)Player_Skill2._skillCount2;
    }
}
