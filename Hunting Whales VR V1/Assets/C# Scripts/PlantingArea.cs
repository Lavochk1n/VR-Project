using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PlantingArea : MonoBehaviour
{
    public GameObject futureCityBuilding;  // Reference to the building prefab to activate in the future.
    public GameObject buildingToDeactivate; // Reference to the building prefab to deactivate.

    private bool hasSeedBeenPlanted = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the seed pack enters the planting area and hasn't been planted yet.
        if (!hasSeedBeenPlanted && other.CompareTag("SeedPack"))
        {
            PlantSeed();
        }
    }

    private void PlantSeed()
    {
        // Deactivate the current building in the future.
        buildingToDeactivate.SetActive(false);

        // Activate the future city building.
        futureCityBuilding.SetActive(true);

        // Destroy the seed pack since it's planted.
        Destroy(GameObject.FindWithTag("SeedPack"));

        hasSeedBeenPlanted = true;

        // You can add more effects, audio, or messages to indicate successful planting.
    }
}