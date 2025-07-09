using System;
using System.Collections;
using UnityEngine;

public class ShootObject : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        InputManager.Instance.OnLeftMouseClicked += HeadToTarget;
        LaunchUpWords(Vector3.zero);
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseClicked -= HeadToTarget;
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

    private void LaunchUpWords(Vector3 target, out float launchSpeed )
    {
        launchSpeed = 1.0f;
        StartCoroutine(MoveToTarget(launchSpeed, target));
    }

    private void LaunchUpWords(Vector3 target)
    {
        float launchSpeed = 2.0f;
        StartCoroutine(MoveToTarget(launchSpeed, target));
    }

    private IEnumerator ShootCube(Vector3 targetPosition)
    {
        LaunchUpWords(Vector3.up, out float launchSpeed);
        yield return new WaitForSeconds(1.0f / launchSpeed);

        StartCoroutine(MoveToTarget(_speed, targetPosition));
    }

    // Signal Methods------------------------------------------------------------------------------

    private void HeadToTarget(Vector3 targetPosition)
    {
        StartCoroutine(ShootCube(targetPosition));
    }
}
