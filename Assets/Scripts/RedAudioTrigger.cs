using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnKeyPress : MonoBehaviour
{
    public AudioClip audioClip; // Audio clip to play
    public float volume = 1.0f; // Volume level
    private AudioSource audioSource;
    private bool isPlaying = false;
    private bool playerInsideCollider = false;

    private void Start()
    {
        // Add an AudioSource component to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the AudioClip to the AudioSource
        audioSource.clip = audioClip;
        // Make sure the audio only plays once
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        // Check if the player pressed the "E" key, the audio is not already playing, and the player is inside the collider
        if (Input.GetKeyDown(KeyCode.E) && !isPlaying && playerInsideCollider)
        {
            // Play the audio with the specified volume
            audioSource.volume = volume;
            audioSource.Play();
            isPlaying = true;
        }
    }

    // Optionally, you can add a method to stop the audio manually if needed
    public void StopAudio()
    {
        isPlaying = false;
        audioSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = false;
        }
    }
}
