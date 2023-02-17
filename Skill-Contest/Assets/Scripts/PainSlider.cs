using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainSlider : MonoBehaviour
{
    Slider slider;
    Text text;

    void Start()
    {
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)GameManager.instance.Pain / 100;
        text.text = GameManager.instance.Pain + "/" + 100;
    }
}
