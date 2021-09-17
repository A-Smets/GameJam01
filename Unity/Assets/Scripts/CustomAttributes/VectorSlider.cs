using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VectorSliderAttribute : PropertyAttribute
{
    //Attribute & PropertyDrawer code posted on GitHub.com by user GucioDev
    //https://github.com/GucioDevs/SimpleMinMaxSlider

    public float min;
    public float max;

    public VectorSliderAttribute(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}