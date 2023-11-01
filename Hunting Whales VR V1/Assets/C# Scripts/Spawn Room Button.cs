using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class ButtonPuzzle : MonoBehaviour
{
    [SerializeField] GameObject lockedDoor;
    [SerializeField] GameObject openDoor;
    [SerializeField] float buttonPressTime = 2f;

    private bool isButtonPressed = false;
    private float buttonPressStartTime;

    private void Start()
    {
        lockedDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    private void Update()
    {
        if (isButtonPressed && Time.time - buttonPressStartTime >= buttonPressTime)
        {
            // The button has been pressed for the specified duration.
            // You can now open the locked door.
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        lockedDoor.SetActive(false);
        openDoor.SetActive(true);
    }

    public void OnButtonPress()
    {
        if (!isButtonPressed)
        {
            // The button is pressed in the past.
            // You can start a timer to simulate the button press duration.
            isButtonPressed = true;
            buttonPressStartTime = Time.time;
        }
    }
}
