using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    public Slider slider;

    public void setMaxLoad(float value) {
        slider.maxValue = value;
        slider.value = value;
    }

    public void setLoad(float value) {
        slider.value = value;
    }
}
