using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _hpSlider;
    public Slider _mpSlider;
    public Slider _avoidSlider;

    // Start is called before the first frame update
    void Start()
    {
        _hpSlider.value = PlayerController._chara1HP;
        _mpSlider.value = PlayerController._mp;
        _avoidSlider.value = PlayerController._avoidCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        _hpSlider.value = (float)PlayerController._chara1HP;
        _mpSlider.value = (float)PlayerController._mp;
        _avoidSlider.value = (float)PlayerController._avoidCount;
    }
}
