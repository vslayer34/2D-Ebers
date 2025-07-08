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

    [SerializeField]
    private bool _wholeNumber;

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

        if (_wholeNumber)
        {
            _valueDisplayTextField.text = newValue.ToString();
        }
        else
        {
            _valueDisplayTextField.text = newValue.ToString(".0");
        }
    }

    public void ForceNewValue(float newValue)
    {
        _scaleSlider.value = newValue;
        if (_wholeNumber)
        {
            _valueDisplayTextField.text = newValue.ToString();
        }
        else
        {
            _valueDisplayTextField.text = newValue.ToString(".0");
        }
    }
}
