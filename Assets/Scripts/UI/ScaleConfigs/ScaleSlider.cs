using System;
using UnityEngine;
using UnityEngine.UI;


public class ScaleSlider : MonoBehaviour
{
    public event Action<ScaleAxis, float> OnValueChanged;

    [SerializeField]
    private Slider _scaleSlider;

    [SerializeField]
    private ScaleAxis _scaleAxis;

    public ScalePanal ParentScalePanal { get; set; }

    public float Value { get => _scaleSlider.value; }



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _scaleSlider.onValueChanged.AddListener(UpdateSliderValue);
    }

    // Signal Methods------------------------------------------------------------------------------

    private void UpdateSliderValue(float newValue)
    {
        OnValueChanged?.Invoke(_scaleAxis, newValue);
    }

    public void ForceNewValue(float newValue)
    {
        _scaleSlider.value = newValue;
    }
}
