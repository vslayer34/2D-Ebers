using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScaleSliderColor : MonoBehaviour
{
    [SerializeField]
    private Slider _scaleSlider;

    [SerializeField]
    private VectorVariable _scaleAxis;

    [SerializeField]
    private Image _fillImage;

    [SerializeField]
    private TextMeshProUGUI _valueText;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _scaleSlider.onValueChanged.AddListener(UpdateSliderColor);
    }

    // Member Methods------------------------------------------------------------------------------

    private void UpdateSliderColor(float value)
    {
        switch (_scaleAxis)
        {
            case VectorVariable.X:
                _fillImage.color = new Color(value / 255.0f, 0.0f, 0.0f, 1.0f);
                _valueText.color = new Color(value / 255.0f, 0.0f, 0.0f, 1.0f);
                break;

            case VectorVariable.Y:
                _fillImage.color = new Color(0.0f, value / 255.0f, 0.0f, 1.0f);
                _valueText.color = new Color(0.0f, value / 255.0f, 0.0f, 1.0f);
                break;

            case VectorVariable.Z:
                _fillImage.color = new Color(0.0f, 0.0f, value / 255.0f, 1.0f);
                _valueText.color = new Color(0.0f, 0.0f, value / 255.0f, 1.0f);
                break;

            default:
                Debug.LogError("No such color");
                break;
        }
    }
}
