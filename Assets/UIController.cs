using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider HPSlider;

    // Start is called before the first frame update
    void Start()
    {
        HPSlider.value = PlayerController._chara1HP;
    }

    // Update is called once per frame
    void Update()
    {
        HPSlider.value = (float)PlayerController._chara1HP;
    }
}
