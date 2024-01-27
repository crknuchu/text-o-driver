using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private float cameraShakeDuration = 0.5f;
    [SerializeField] private float cameraShakeDecreaseFactor = 1f;
    [SerializeField] private float cameraShakeAmount = 1f;
    // coroutine
    public IEnumerator Shake()
    {
        var originalPos = mainCamera.transform.localPosition;
        var duration = cameraShakeDuration;
        while(duration > 0)
        {
            mainCamera.transform.localPosition = originalPos + Random.insideUnitSphere * cameraShakeAmount;
            duration -= Time.deltaTime * cameraShakeDecreaseFactor;
            yield return null;
        }
        mainCamera.transform.localPosition = originalPos;
    }
}

