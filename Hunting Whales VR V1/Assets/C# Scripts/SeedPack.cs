using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeedPack : MonoBehaviour
{
    public GameObject plantingArea; // Reference to the designated planting area.
    public GameObject futureCityBuilding; // Reference to the building prefab to activate in the future.
    public GameObject buildingToDeactivate; // Reference to the building prefab to deactivate.

    private bool hasBeenPlanted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenPlanted) return;

        // Check if the player is in the future and the Y button is pressed.
        if (IsInFuture() && IsYButtonPressed())
        {
            PlantSeed();
        }
    }

    private void PlantSeed()
    {
        // Deactivate the current building in the future.
        buildingToDeactivate.SetActive(false);

        FindObjectOfType<AudioManager>().Play("TreePlant");

        // Activate the future city building.
        futureCityBuilding.SetActive(true);


        // Destroy the seed pack since it's planted.
        Destroy(gameObject);

        hasBeenPlanted = true;

        // You can add more effects, audio, or messages to indicate successful planting.
    }

    private bool IsInFuture()
    {
        // Implement your logic to check if the player is in the future. You can use your TimeTravel script's logic for this.
        return false; // Replace with your actual logic.
    }

    private bool IsYButtonPressed()
    {
        // Replace this with code to check if the Y button is pressed on the VR controller.
        return false; // Example placeholder; you'll need to implement this.
    }
}

