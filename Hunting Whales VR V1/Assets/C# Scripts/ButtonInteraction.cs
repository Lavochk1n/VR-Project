using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.Rendering;

public class ButtonInteraction : MonoBehaviour {
    public GameObject ObjectToDisable;
    public GameObject ObjectToEnable;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hand"))  // Assuming the hand has a "Hand" tag.
        {
            ObjectToDisable.SetActive(false);
            ObjectToEnable.SetActive(true);
        }
    }
}