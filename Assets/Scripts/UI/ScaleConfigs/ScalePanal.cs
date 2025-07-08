using System;
using UnityEngine;
using UnityEngine.UI;


public enum VectorVariable
{
    X,
    Y,
    Z
}
public class ScalePanal : MonoBehaviour, ISlidableVariables
{
    public Action<float> OnUniformSelected;

    public static ScalePanal Instance { get; private set; }

    public Vector3 ScaleValues { get; private set; } = Vector3.one;

    [SerializeField]
    private Toggle _uniformToggle;

    [SerializeField]
    private SliderConfig[] _scaleSliders;





    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
        }
    }

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

    public void UpdateSliderValuesEffects(VectorVariable axis, float value)
    {
        Vector3 changeInScaleValues = Vector3.zero;


        if (_uniformToggle.isOn)
        {
            foreach (var scaleSlider in _scaleSliders)
            {
                scaleSlider.ForceNewValue(value);
                changeInScaleValues = new Vector3(value, value, value);
            }
        }
        else
        {
            switch (axis)
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
        }

        

        ScaleValues = changeInScaleValues;
    }
}
