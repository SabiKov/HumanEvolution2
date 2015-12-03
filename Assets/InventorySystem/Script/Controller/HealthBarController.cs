using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health bar controller
/// </summary>
public class HealthBarController : MonoBehaviour, IHealthBarController
{

    /// <summary>
    /// Slider color settings by percent value
    /// </summary>
    [Serializable]
    public struct ColoringOption
    {
        public float percentValue;
        public Color colour;
    }

    public Image SliderImage;
    public List<ColoringOption> ColoringOptions;

    // Use this for initialization
    public void Start()
    {
        this.SetHealth(1.0f);
    }

    /// <summary>
    /// Set slider position
    /// </summary>
    /// <param name="percentValue">percent value</param>
    public void SetHealth(float percentValue)
    {
        this.SliderImage.fillAmount = percentValue;
        this.ColoringSlider(percentValue);
    }

    /// <summary>
    /// Change slider image color value by percent value
    /// </summary>
    /// <param name="percentValue">percent value</param>
    private void ColoringSlider(float percentValue)
    {
        var maxValue = float.MinValue;
        var color = Color.white;
        foreach(var option in ColoringOptions) {
            if(percentValue > option.percentValue && percentValue > maxValue) {
                maxValue = option.percentValue;
                color = option.colour;
            }
        }

        this.SliderImage.color = color;
    }
}
