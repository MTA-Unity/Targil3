using System.Collections;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] public float _moveTime = 1.0f;

    void Start()
    {
        StartCoroutine(MoveToPosition());
    }

    IEnumerator MoveToPosition()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, _targetPosition, elapsedTime / _moveTime);
            yield return null;
        }

        transform.position = _targetPosition; // Ensures that the target position is exactly reached
    }
}