using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace YNL.Tools.UI
{
    public class FPS : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _fpsText;
        private Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(FPSOverSecond());
        }

        private IEnumerator FPSOverSecond()
        {
            yield return new WaitForSeconds(1);

            _fpsText.text = $"{(int)(1 / Time.deltaTime * Time.timeScale)}";

            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(FPSOverSecond());
        }
    }
}
