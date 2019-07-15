using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosterManager : MonoBehaviour
{
    public Image[] images;

    [Header("Animation")]
    public float animationTime;
    public AnimationCurve animationCurve;

    private bool isParallaxActive = true;

    public void ToggleOverlay()
    {
        StopAllCoroutines();

        Array.Reverse(images);

        isParallaxActive = !isParallaxActive;

        for (int i = 0; i < images.Length; i++)
        {
            StartCoroutine(AnimateImage(images[i], isParallaxActive ? new Color(1, 1, 1, 0) : Color.white, animationTime, animationTime * i));
        }
    }

    IEnumerator AnimateImage(Image image, Color targetColor, float time, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0;
        Color startColor = image.color;

        while(elapsedTime < time)
        {
            image.color = Color.Lerp(startColor, targetColor, animationCurve.Evaluate(elapsedTime / time));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        image.color = targetColor;
    }
}
