using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SliderConfig : MonoBehaviour
{
    public event Action<VectorVariable, float> OnValueChanged;

    [SerializeField]
    private Slider _scaleSlider;

    [SerializeField]
    private VectorVariable _scaleAxis;

    [SerializeField]
    private TextMeshProUGUI _valueDisplayTextField;

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
        _valueDisplayTextField.text = newValue.ToString();
    }

    public void ForceNewValue(float newValue)
    {
        _scaleSlider.value = newValue;
        _valueDisplayTextField.text = newValue.ToString();
    }
}
