using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerScript : MonoBehaviour
{
    // Reference to the Animator component
    public Animator animator;

    // Names of the animations to trigger
    public string[] animationNames;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is colliding with the collider and pressing the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if animator is assigned
            if (animator != null)
            {
                // Trigger each animation by name
                foreach (string animName in animationNames)
                {
                    animator.SetTrigger(animName);
                }
            }
            else
            {
                Debug.LogError("Animator reference is not assigned!");
            }
        }
    }
}
