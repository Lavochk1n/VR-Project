using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeedPickup : MonoBehaviour
{
    // Add code to handle picking up the seed using VR controller input.
    // You can use XR Interaction Toolkit or any other VR interaction system you prefer.
}

public class SeedPlanting : MonoBehaviour
{
    [SerializeField] GameObject present, past;
    [SerializeField] bool presentIsVisible = true;
    [SerializeField] GameObject futureBuilding; // Reference to the building in the future.

    // Add any necessary variables for tracking the state of the puzzle.

    // ...

    void SwitchActiveLayers()
    {
        presentIsVisible = !presentIsVisible;
        present.SetActive(!present.activeSelf);
        past.SetActive(!past.activeSelf);

        // Check if the seed has been planted in the past and update the future accordingly.
        if (seedPlantedInPast())
            FindObjectOfType<AudioManager>().Play("TreePlant");
        {
            futureBuilding.SetActive(false); // Disable the building in the future.
        }
    }

    // ...

    private bool seedPlantedInPast()
    {
        // Add logic to check if the seed is planted in the past.
        return true; // Replace with your own logic.
    }
}
