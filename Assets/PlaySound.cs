using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target; 
    public float triggerDistance = 3f; 

    private AudioSource audioSource;
    private bool soundPlayed = false;
    private bool inRange = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); 
    }

    void Update()
{
    float distance = Vector3.Distance(transform.position, target.position);
    Debug.Log("Distance: " + distance);

    if (!soundPlayed && distance < triggerDistance)
    {
        // Character is close enough to the target, play the sound
        audioSource.Play();
        soundPlayed = true;
        inRange = true;
    }
    else if (soundPlayed && distance >= triggerDistance)
    {
        // Character moved away from the target, stop the sound
        audioSource.Stop();
        soundPlayed = false;
        inRange = false;
    }
}
}
