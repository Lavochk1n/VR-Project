using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.Rendering;

public class TimeTravel : MonoBehaviour
{
    [SerializeField] GameObject present, past;
    [SerializeField] float effectRatePerSecond = 1;
    [SerializeField] float cooldownTime = 1.0f;
    [SerializeField] float transitionDuration = 0.5f;

    private bool presentIsVisible = true;
    private float timeToEffect = 0f;
    private float lastEffectTime = 0f;
    private XRController leftController;
    private bool isCoolingDown = false;

    void Start()
    {
        present.SetActive(presentIsVisible);
        past.SetActive(!presentIsVisible);
        leftController = GetComponent<XRController>();
    }

    void Update()
    {
        if (isCoolingDown)
        {
            if (Time.time - lastEffectTime >= cooldownTime)
            {
                isCoolingDown = false;
            }
        }
        else
        {
            // Check for the "Y" button press on the left controller
            if (leftController.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
            {
                if (Time.time >= timeToEffect)
                {
                    timeToEffect = Time.time + 1 / effectRatePerSecond;
                    lastEffectTime = Time.time;
                    isCoolingDown = true;
                    StartCoroutine(TransitionEffect());
                }
            }
        }
    }

    IEnumerator TransitionEffect()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / transitionDuration;
            float lerpedValue = Mathf.Lerp(0, 1, t);
            ApplyTimeTravelEffect(lerpedValue);
            yield return null;
        }

        SwitchActiveLayers(); // Complete the time travel effect
    }

    void ApplyTimeTravelEffect(float t)
    {
        // You can implement your own visual effect here, e.g., adjust lighting or screen color based on 't'.
    }

    void SwitchActiveLayers()
    {
        presentIsVisible = !presentIsVisible;
        present.SetActive(presentIsVisible);
        past.SetActive(!presentIsVisible);
    }
}