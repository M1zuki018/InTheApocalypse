using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _hpSlider;
    public Slider _avoidSlider;
    public Slider _skill1Slider;
    public Slider _skill2Slider;

    [SerializeField] GameObject _group1;
    [SerializeField] GameObject _group2;


    // Start is called before the first frame update
    void Start()
    {
        _hpSlider.value = PlayerController._chara1HP;
        
        _avoidSlider.value = PlayerController._avoidCoolTime;
        _skill1Slider.value = Player_Skill1._skillCoolTime1;
        _skill2Slider.value = Player_Skill2._skillCoolTime2;

        _group1.SetActive(false);
        _group2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _hpSlider.value = (float)PlayerController._chara1HP;
        _avoidSlider.value = (float)PlayerController._avoidCount;
        _skill1Slider.value = (float)Player_Skill1._skillTimerCount1;
        _skill2Slider.value = (float)Player_Skill2._skillTimerCount2;

    }

    public void Group1() 
    {
        _group1.SetActive(true);
    }

    public void Group2()
    {
        _group2.SetActive(true);
    }

    
}
