using System.Collections;
using UnityEngine;

public class ShootObject : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        LaunchUpWords();
    }

    // Member Methods------------------------------------------------------------------------------

    private IEnumerator MoveToTarget(float speed, Vector3 targetPosition)
    {
        Vector3 currentPosition = transform.position;
        float timer = 0.0f;
        float totalTime = 1.0f / speed;

        while (timer <= totalTime)
        {
            transform.position = Vector3.Lerp(currentPosition, targetPosition, timer / totalTime);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    private void LaunchUpWords()
    {
        float launchSpeed = 0.5f;
        StartCoroutine(MoveToTarget(launchSpeed, Vector3.up));
    }
}
