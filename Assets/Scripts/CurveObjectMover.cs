using System.Collections;
using UnityEngine;

public class CurveObjectMover : MonoBehaviour
{
    [SerializeField] private Transform _movingObject;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] public float _moveTime = 1.0f;
    [SerializeField] private AnimationCurve _animationCurve;
    
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = _movingObject.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movingObject.position = _startPosition;
            StartCoroutine(MoveToPosition());   
        }
    }

    IEnumerator MoveToPosition()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;
            var t = _animationCurve.Evaluate(elapsedTime / _moveTime);
            
            elapsedTime += Time.deltaTime;
            _movingObject.position = Vector3.Lerp(startPosition, _targetTransform.position, t);
            yield return null;
        }

        _movingObject.position = _targetTransform.position; // Ensures that the target position is exactly reached
    }
}