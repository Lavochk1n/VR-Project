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

    public Animator animator;

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
            if (Input.GetButtonDown("XRI_Left_TriggerButton"))
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
        if (presentIsVisible == true) 
        {
            FindObjectOfType<AudioManager>().Play("PastCityBackground");
            FindObjectOfType<AudioManager>().StopPlaying("FutureCityBackground");
        }

        if (presentIsVisible == false) 
        {
            FindObjectOfType<AudioManager>().Play("FutureCityBackground");
            FindObjectOfType<AudioManager>().StopPlaying("PastCityBackground");
        }

    }

    IEnumerator TransitionEffect()
    {
        FindObjectOfType<AudioManager>().Play("TimeTravel");
        animator.SetTrigger("TimeTravel");
        yield return null;
             if (presentIsVisible == true)
             {
                presentIsVisible = false;
             }
                 else
                 {
                     if (presentIsVisible == false)
                        presentIsVisible = true;
                 }

        SwitchActiveLayers(); // Complete the time travel effect
    }


    void SwitchActiveLayers()
    {
        presentIsVisible = !presentIsVisible;
        present.SetActive(presentIsVisible);
        past.SetActive(!presentIsVisible);
    }
}