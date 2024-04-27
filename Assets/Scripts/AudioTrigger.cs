using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip audioClip; // Audio clip to play
    private AudioSource audioSource;
    private bool isInside = false;

    private void Start()
    {
        // Add an AudioSource component to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the AudioClip to the AudioSource
        audioSource.clip = audioClip;
        // Make sure the audio only plays once
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Set flag to indicate player is inside
            isInside = true;
            // Play the audio if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Set flag to indicate player is outside
            isInside = false;
            // Stop the audio
            audioSource.Stop();
        }
    }

    // Optionally, you can add a method to stop the audio manually if needed
    public void StopAudio()
    {
        isInside = false;
        audioSource.Stop();
    }
}

