using UnityEngine;

public class ScaleHanlder : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = HUD.Instance.ScalePanalUI.ScaleValues;
    }
}
