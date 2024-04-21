using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Extension.Method;
using YNL.Tools.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement : MonoBehaviour
{
    public bool _canDash = true;
    public float _speed = 0.05f;
    public float _dashDistance;
    private Vector2 _movingInput;
    [SerializeField] private TrailRenderer tr;
    private Coroutine _dashingCoroutine;

    void Update()
    {
        _movingInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += ToVector3(_movingInput * _speed.Oscillate(120));

        if (MInput.PressSpace() && _canDash)
        {
            _canDash = false;
            if (!_dashingCoroutine.IsNull()) StopCoroutine(_dashingCoroutine);
            _dashingCoroutine = StartCoroutine(Dashing(transform.position + ToVector3(_movingInput.normalized * _dashDistance), 0.75f));
        }            
    }
    public Vector3 ToVector3(Vector2 input) => new Vector3(input.x, input.y, 0);

    public IEnumerator Dashing(Vector2 destination, float duration, TweenType tween = TweenType.ExponentialInterpolation)
    {
        float elapsedTime = 0f;

        Vector3 startPosition = transform.position;
        tr.emitting = true;
        while (elapsedTime < duration * 0.15f)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / duration);

            if (tween == TweenType.ExponentialInterpolation) transform.localPosition = Vector2.Lerp(transform.localPosition, destination, normalizedTime);
            if (tween == TweenType.LinearInterpolation) transform.localPosition = Vector2.Lerp(startPosition, destination, normalizedTime);

            yield return null;
        }
        tr.emitting = false;

        // After doing Dash coroutine, wait for 0.5 second
        yield return new WaitForSeconds(0.5f);
        _canDash = true;
    }
}
