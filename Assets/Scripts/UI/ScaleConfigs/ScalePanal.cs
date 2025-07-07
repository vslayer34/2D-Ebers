using System;
using UnityEngine;
using UnityEngine.UI;


public enum ScaleAxis
{
    X,
    Y,
    Z
}
public class ScalePanal : MonoBehaviour
{
    public Action<float> OnUniformSelected;
    public Vector3 ScaleValues { get; private set; } = Vector3.one;

    [SerializeField]
    private Toggle _uniformToggle;

    [SerializeField]
    private ScaleSlider[] _scaleSliders;

    



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        foreach (var scaleSlider in _scaleSliders)
        {
            scaleSlider.OnValueChanged += UpdateScaleValues;
        }
    }

    private void OnDestroy()
    {
        foreach (var scaleSliders in _scaleSliders)
        {
            scaleSliders.OnValueChanged -= UpdateScaleValues;
        }
    }

    // Signal Methods------------------------------------------------------------------------------

    private void UpdateScaleValues(ScaleAxis axis, float value)
    {
        Vector3 newScaleValues = Vector3.one;


        if (_uniformToggle.isOn)
        {
            foreach (var scaleSlider in _scaleSliders)
            {
                scaleSlider.ForceNewValue(value);
                newScaleValues = new Vector3(value, value, value);
            }
        }
        else
        {
            switch (axis)
            {
                case ScaleAxis.X:
                    newScaleValues.x = value;
                    break;

                case ScaleAxis.Y:
                    newScaleValues.y = value;
                    break;

                case ScaleAxis.Z:
                    newScaleValues.z = value;
                    break;

                default:
                    Debug.LogError("There's no such axis");
                    break;
            }
        }

        

        ScaleValues = newScaleValues;
        Debug.Log(ScaleValues);
    }
}
