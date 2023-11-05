using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    CharacterController controller;
    private void Update()
    {
        Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);

        // The speed on the x-z plane ignoring any speed
        float horizontalSpeed = horizontalVelocity.magnitude;
        // The speed from gravity or jumping
        float verticalSpeed = controller.velocity.y;
        // The overall speed
        float overallSpeed = controller.velocity.magnitude;

        if(overallSpeed > 0.1)
        {
            FindObjectOfType<AudioManager>().Play("FootSteps");
        }
        if (overallSpeed <= 0.1)
        {
            FindObjectOfType<AudioManager>().StopPlaying("FootSteps");
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "FutureCity")
        {
            FindObjectOfType<AudioManager>().Play("FutureCityBackground");
        }
        if (col.gameObject.tag == "PastCity")
        {
            FindObjectOfType<AudioManager>().Play("PastCityBackground");
        }
        if (col.gameObject.tag == "Lab")
        {
            FindObjectOfType<AudioManager>().Play("LabBackground");
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "FutureCity")
        {
            FindObjectOfType<AudioManager>().StopPlaying("FutureCityBackground");
        }
        if (col.gameObject.tag == "PastCity")
        {
            FindObjectOfType<AudioManager>().StopPlaying("PastCityBackground");
        }
        if (col.gameObject.tag == "Lab")
        {
            FindObjectOfType<AudioManager>().StopPlaying("LabBackground");
        }
    }
}
