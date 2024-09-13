using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight_mode : MonoBehaviour
{
    public Light flashlight;
    public float fadeDuration = 10f; // Thời gian để tắt đèn hoàn toàn
    private bool isLightOn = true;

    [SerializeField] private AudioSource flashlightAudioSource = null;
    [SerializeField] private float openDelay = 0;

    void Start()
    {
        // Bắt đầu Coroutine để tự động tắt đèn theo kiểu ánh sáng yếu dần
        StartCoroutine(FadeOutFlashlight(fadeDuration));
    }

    void Update()
    {
        // Bật đèn lại khi nhấn nút "F"
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnOnFlashlight();

        }
    }

    IEnumerator FadeOutFlashlight(float duration)
    {
        float startIntensity = flashlight.intensity;
        float targetIntensity = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newIntensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / duration);
            flashlight.intensity = newIntensity;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Tắt đèn pin sau khi hoàn thành ánh sáng yếu dần
        TurnOffFlashlight();
    }

    void TurnOnFlashlight()
    {
        // Bật âm thanh đèn
        if (flashlight.intensity < 0.1f)
        {
            flashlightAudioSource.PlayDelayed(openDelay);
        }

        // Bật đèn pin và đặt lại thời gian tự động tắt
        flashlight.enabled = true;
        flashlight.intensity = 2.3f;
        StartCoroutine(FadeOutFlashlight(fadeDuration));
        isLightOn = true;
       
        Debug.Log("on");
    }

    void TurnOffFlashlight()
    {
        // Tắt đèn pin và đặt lại trạng thái
        flashlight.enabled = false;
        isLightOn = false;
    }
}