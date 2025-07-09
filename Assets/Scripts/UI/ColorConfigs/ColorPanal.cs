using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanal : MonoBehaviour, ISlidableVariables
{
    public Action<Color> OnColorUpdated;

    public Vector3 ScaleValues { get; private set; } = Vector3.zero;

    [SerializeField]
    private Image _colorDisplay;

    [SerializeField]
    private SliderConfig[] _scaleSliders;





    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        foreach (var scaleSlider in _scaleSliders)
        {
            scaleSlider.OnValueChanged += UpdateSliderValuesEffects;
        }
    }

    private void OnDestroy()
    {
        foreach (var scaleSliders in _scaleSliders)
        {
            scaleSliders.OnValueChanged -= UpdateSliderValuesEffects;
        }
    }

    // Interface Methods---------------------------------------------------------------------------

    public void UpdateSliderValuesEffects(VectorVariable variableType, float value)
    {
        Vector3 changeInScaleValues = Vector3.zero;

        switch (variableType)
        {
            case VectorVariable.X:
                changeInScaleValues.x = value;
                changeInScaleValues.y = ScaleValues.y;
                changeInScaleValues.z = ScaleValues.z;
                break;

            case VectorVariable.Y:
                changeInScaleValues.x = ScaleValues.x;
                changeInScaleValues.y = value;
                changeInScaleValues.z = ScaleValues.z;
                break;

            case VectorVariable.Z:
                changeInScaleValues.x = ScaleValues.x;
                changeInScaleValues.y = ScaleValues.y;
                changeInScaleValues.z = value;
                break;

            default:
                Debug.LogError("There's no such axis");
                break;
        }

        ScaleValues = changeInScaleValues;

        Color currentColor = new Color(ScaleValues.x / 255.0f, ScaleValues.y / 255.0f, ScaleValues.z / 255.0f, 1.0f);
        _colorDisplay.color = currentColor;
        OnColorUpdated?.Invoke(currentColor);
    }
}
