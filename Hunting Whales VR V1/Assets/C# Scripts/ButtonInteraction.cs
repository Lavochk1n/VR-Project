using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] GameObject lockedDoorPrefab; // Reference to the locked door prefab
    [SerializeField] GameObject openDoorPrefab;   // Reference to the open door prefab

    private bool isButtonPressed = false;

    public void OnTriggerEnter(Collider other)
    {
        if (!isButtonPressed && other.CompareTag("Hand"))
        {
            // Disable the locked door
            lockedDoorPrefab.SetActive(false);

            // Enable the open door
            openDoorPrefab.SetActive(true);

            isButtonPressed = true;
        }
    }
}
