using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeStrength = 1;
    private float shakeDuration = 1;

    // Call this method to initiate camera shake
    public void Shake(float strength, float duration)
    {
        shakeStrength = strength;
        shakeDuration = duration;
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPosition = transform.position;

        while (shakeDuration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeStrength;

            // Reduce duration over time to create a smooth shake effect
            shakeDuration -= Time.deltaTime;

            yield return null;
        }

        // Reset the camera position after shaking
        transform.position = originalPosition;
    }
}
