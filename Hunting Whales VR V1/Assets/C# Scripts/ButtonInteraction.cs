using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.Rendering;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] GameObject lockedDoorPrefab; // The locked door prefab
    [SerializeField] GameObject openDoorPrefab;   // The open door prefab

    private bool isDoorOpen = false;

    private void Start()
    {
        // Spawn the initial locked door in the future
        Instantiate(lockedDoorPrefab, transform.position, transform.rotation);
    }

    public void OnButtonPress()
    {
        if (!isDoorOpen)
        {
            // Delete the current door prefab (locked door) in the future
            Destroy(GameObject.FindGameObjectWithTag("Door"));

            // Spawn the open door prefab in the future
            Instantiate(openDoorPrefab, transform.position, transform.rotation);

            isDoorOpen = true;
        }
    }
}