using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour {
    public LabPuzzle[] pedestals; // Reference to the LabPuzzle components on the pedestals
    public GameObject victoryScreen; // Reference to the victory screen GameObject

    void Update() {
        if (CheckVictoryCondition()) {
            // Show the victory screen when the victory condition is met
            victoryScreen.SetActive(true);
        }
    }

    bool CheckVictoryCondition() {
        foreach (var pedestal in pedestals) {
            if (!pedestal.IsSnapped) {
                return false; // If any object is not snapped, the condition is not met
            }
        }

        return true; // All objects are snapped, the condition is met
    }
}
