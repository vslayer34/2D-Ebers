using System;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    private Material _cubeMaterial;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _cubeMaterial = GetComponent<Renderer>().sharedMaterial;
        _cubeMaterial = GetComponent<Renderer>().sharedMaterial = new Material(_cubeMaterial);
    }

    private void Start()
    {
        HUD.Instance.ColorPanalUI.OnColorUpdated += UpdateCubeColor;
    }

    private void OnDestroy()
    {
        HUD.Instance.ColorPanalUI.OnColorUpdated -= UpdateCubeColor;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void UpdateCubeColor(Color color) => _cubeMaterial.color = color;
}
