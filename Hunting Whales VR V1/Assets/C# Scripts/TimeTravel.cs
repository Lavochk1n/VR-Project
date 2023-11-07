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
            if (Input.GetButtonDown("XRI_Left_SecondaryButton"))
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


        IEnumerator TransitionEffect()
        {
            animator.SetTrigger("TimeTravel");
            yield return new WaitForSeconds(1f);

            SwitchActiveLayers(); // Complete the time travel effect

            animator.SetTrigger("TimeTravel");

        }


        void SwitchActiveLayers()
        {
            presentIsVisible = !presentIsVisible;
            present.SetActive(presentIsVisible);
            past.SetActive(!presentIsVisible);
        }
    }
}