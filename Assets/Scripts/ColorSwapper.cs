using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ColorSwapper : MonoBehaviour
{
    [SerializeField] public Color _targetColor = Color.red;
    [SerializeField] public float _duration = 1.0f;

    void Start()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color startColor = spriteRenderer.color;
        float elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(startColor, _targetColor, elapsedTime / _duration);
            yield return null;
        }

        spriteRenderer.color = _targetColor; // Ensures that the target color is exactly reached
    }
}
