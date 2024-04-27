using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ScreenZoom : MonoBehaviour
{
    public Text exitText; // Reference to the UI text element
    public CinemachineVirtualCamera originalVirtualCamera; // Reference to the player's original virtual camera
    public CinemachineVirtualCamera fixedVirtualCamera; // Reference to the fixed virtual camera
    private bool isFixedCameraActive = false; // Flag to track if the fixed camera is active


    void Start()
    {
        // Ensure the exit text is initially hidden
        exitText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            // Display message to press E to switch cameras
            Debug.Log("Press 'E' to switch cameras.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the player is inside the trigger zone and presses the E key
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle between the original camera and the fixed camera
            if (isFixedCameraActive)
            {
                // Switch to the original camera
                fixedVirtualCamera.Priority = 0;
                originalVirtualCamera.Priority = 1;
                isFixedCameraActive = false;
            }
            else
            {
                // Switch to the fixed camera
                originalVirtualCamera.Priority = 0;
                fixedVirtualCamera.Priority = 1;
                isFixedCameraActive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exited the trigger zone
        if (other.CompareTag("Player"))
        {
            // Revert to the original camera
            fixedVirtualCamera.Priority = 0;
            originalVirtualCamera.Priority = 1;
            isFixedCameraActive = false;
            // Remove interaction message
            Debug.Log("Exited camera switch area.");
        }
        exitText.gameObject.SetActive(true); // Display the UI text
        StartCoroutine(HideText()); // Hide the UI text after a delay
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(7f); // Adjust the delay as needed
        exitText.gameObject.SetActive(false); // Hide the UI text
    }
}
