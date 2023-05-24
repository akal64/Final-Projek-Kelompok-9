using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnim : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private float fadeDuration = 1.5f;

    private void Start() {
        StartCoroutine(FadeOutAndDisable());
    }

    private System.Collections.IEnumerator FadeOutAndDisable() {
        yield return new WaitForSeconds(fadeDuration);

        float currentTime = 0f;
        float startAlpha = canvas.alpha;
        float targetAlpha = 0f;

        while (currentTime < fadeDuration) {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / fadeDuration;
            canvas.alpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);
            yield return null;
        }

        canvas.gameObject.SetActive(false);
    }
}
