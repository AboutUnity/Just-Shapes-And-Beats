using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Extension.Method;
using YNL.Tools.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement : MonoBehaviour
{
    public float _speed = 0.05f;
    public float _dashDistance;
    private Vector2 _movingInput;

    private Coroutine _dashingCoroutine;

    void Update()
    {
        _movingInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += ToVector3(_movingInput * _speed.Oscillate(120));

        if (MInput.PressSpace())
        {
            if (!_dashingCoroutine.IsNull()) StopCoroutine(_dashingCoroutine);
            _dashingCoroutine = StartCoroutine(Dashing(transform.position + ToVector3(_movingInput.normalized * _dashDistance), 1));
        }

    }

    public Vector3 ToVector3(Vector2 input) => new Vector3(input.x, input.y, 0);

    public IEnumerator Dashing(Vector2 destination, float duration, TweenType tween = TweenType.ExponentialInterpolation)
    {
        float elapsedTime = 0f;

        Vector3 startPosition = transform.position;

        while (elapsedTime < duration - 0.85f)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / duration);

            if (tween == TweenType.ExponentialInterpolation) transform.localPosition = Vector2.Lerp(transform.localPosition, destination, normalizedTime);
            if (tween == TweenType.LinearInterpolation) transform.localPosition = Vector2.Lerp(startPosition, destination, normalizedTime);

            yield return null;
        }
    }
}
