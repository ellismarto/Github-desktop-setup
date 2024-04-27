using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public Text promptText; // Reference to the UI Text element
    private bool hasEntered = false;

    private void Start()
    {
        // Disable the UI Text element at the start
        promptText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is tagged as "Player"
        if (other.CompareTag("Player") && !hasEntered)
        {
            // Enable the UI Text element
            promptText.gameObject.SetActive(true);
            // Set the text of the UI Text element
            hasEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Disable the UI Text element
            promptText.gameObject.SetActive(false);
            hasEntered = false;
        }
    }
}

