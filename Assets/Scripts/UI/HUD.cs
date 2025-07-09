using System;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }

    [field: SerializeField]
    public ScalePanal ScalePanalUI { get; private set; }

    [field: SerializeField]
    public ColorPanal ColorPanalUI { get; private set; }

    [SerializeField]
    private ResetButton _resetBtn;



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

    // Member Methods------------------------------------------------------------------------------

    public void ShowResetButton()
    {
        _resetBtn.gameObject.SetActive(true);
    }
}
