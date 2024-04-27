using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderCounter : MonoBehaviour
{
    public int maxCount = 7; // Maximum number of objects allowed in the collider
    private int currentCount = 0; // Current number of objects in the collider
    public Text countText; // Reference to the UI Text element to display count
    public Text maxCountText;
    public AudioClip audioClip; // Audio clip to play
    private AudioSource audioSource;

    private bool maxCountTextDisplayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("canPickUp")) // Check if the collided object is a throwable object
        {
            currentCount++; // Increment the count
            UpdateCountUI(); // Update the UI text
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void UpdateCountUI()
    {
        if (countText != null)
        {
            countText.text = "Boxes Cleared: " + currentCount.ToString() + " / " + maxCount.ToString(); // Update UI text
        }

        if (currentCount >= maxCount && !maxCountTextDisplayed)
        {
            if (maxCountText != null)
            {
                maxCountText.gameObject.SetActive(true); // Activate the max count text
                countText.gameObject.SetActive(false); // Deactivate the original count text
                maxCountTextDisplayed = true; // Set the flag to true
                StartCoroutine(DestroyMaxCountTextAfterDelay()); // Start coroutine to destroy max count text
            }
            Debug.Log("Collider is full!"); // You can add additional actions here when the collider is full
        }
    }

    private IEnumerator DestroyMaxCountTextAfterDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        if (maxCountText != null)
        {
            Destroy(maxCountText.gameObject); // Destroy the max count text
        }
    }

    private void Start()
    {
        // Ensure the max count text is initially hidden
        if (maxCountText != null)
        {
            maxCountText.gameObject.SetActive(false);
        }
        audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the AudioClip to the AudioSource
        audioSource.clip = audioClip;
        // Make sure the audio only plays once
        audioSource.playOnAwake = false;
    }
}

