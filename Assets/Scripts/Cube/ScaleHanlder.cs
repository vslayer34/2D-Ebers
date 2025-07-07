using UnityEngine;

public class ScaleHanlder : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = ScalePanal.Instance.ScaleValues;
    }
}
