using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    private Material _cubeMaterial;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _cubeMaterial = GetComponent<Renderer>().sharedMaterial;
    }
}
