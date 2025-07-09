using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour, ITarget
{
    // Game Loop Methods---------------------------------------------------------------------------

    private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        FinishGame();
    }

    // Interface Methods---------------------------------------------------------------------------

    public Vector3 MyPosition => transform.position;

    public void FinishGame()
    {
        HUD.Instance.ShowResetButton();
    }

}
