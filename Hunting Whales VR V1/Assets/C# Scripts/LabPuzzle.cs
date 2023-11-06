using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPuzzle : MonoBehaviour {
    public GameObject snapObject; // The object that will snap to this pedestal
    public Transform pedestal; // The pedestal where the object should snap
    public float snapDistance = 0.1f; // Adjust this value to control the snapping distance

    private bool isSnapped = false;
    public bool IsSnapped => isSnapped; // Add a public property to check if the object is snapped

    void Update() {
        if (!isSnapped) {
            float distance = Vector3.Distance(snapObject.transform.position, pedestal.position);

            if (distance < snapDistance) {
                SnapObjectToPedestal();
            }
        }
    }

    void SnapObjectToPedestal() {
        snapObject.transform.position = pedestal.position;
        snapObject.transform.rotation = pedestal.rotation;
        snapObject.GetComponent<Rigidbody>().isKinematic = true; // Optional: make the object non-interactive

        isSnapped = true;
    }

    public void ReleaseObject() {
        snapObject.GetComponent<Rigidbody>().isKinematic = false; // Optional: make the object interactive again
        isSnapped = false;
    }
}
