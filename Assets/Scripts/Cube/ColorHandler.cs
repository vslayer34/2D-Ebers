using System;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    private Material _cubeMaterial;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _cubeMaterial = GetComponent<Renderer>().sharedMaterial;
    }

    private void Start()
    {
        ColorPanal.Instance.OnColorUpdated += UpdateCubeColor;
    }

    private void OnDestroy()
    {
        ColorPanal.Instance.OnColorUpdated -= UpdateCubeColor;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void UpdateCubeColor(Color color) => _cubeMaterial.color = color;
}
