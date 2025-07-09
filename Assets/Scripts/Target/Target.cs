using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour, ITarget
{
    public Vector3 MyPosition => transform.position;

    private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
