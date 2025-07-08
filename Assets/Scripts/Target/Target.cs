using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour, IPointerDownHandler
{
    private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);   
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerClick)
        Debug.Log("I'm clicked");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("I'm clicked");
    }
}
