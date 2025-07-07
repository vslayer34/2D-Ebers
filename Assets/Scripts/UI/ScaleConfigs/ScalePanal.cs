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

    public static ScalePanal Instance { get; private set; }

    public Vector3 ScaleValues { get; private set; } = Vector3.one;

    [SerializeField]
    private Toggle _uniformToggle;

    [SerializeField]
    private ScaleSlider[] _scaleSliders;





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
                case ScaleAxis.X:
                    changeInScaleValues.x = value;
                    changeInScaleValues.y = ScaleValues.y;
                    changeInScaleValues.z = ScaleValues.z;
                    break;

                case ScaleAxis.Y:
                    changeInScaleValues.x = ScaleValues.x;
                    changeInScaleValues.y = value;
                    changeInScaleValues.z = ScaleValues.z;
                    break;

                case ScaleAxis.Z:
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
        Debug.Log(ScaleValues);
    }
}
