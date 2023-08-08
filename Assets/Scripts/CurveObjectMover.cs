using System.Collections;
using DG.Tweening;
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

            var tween = _movingObject.DOMove(_targetTransform.position, _moveTime).SetEase(_animationCurve);
        }
    }
}