using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterBehaviour : MonoBehaviour
{
    // References to the Animator components
    public Animator[] animators;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is colliding with the collider and pressing the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if all animators are assigned
            if (AreAnimatorsAssigned())
            {
                // Trigger each animator
                foreach (Animator animator in animators)
                {
                    animator.SetTrigger("Open");
                }
            }
            else
            {
                Debug.LogError("One or more animators are not assigned!");
            }
        }
    }

    // Check if all animators are assigned
    bool AreAnimatorsAssigned()
    {
        foreach (Animator animator in animators)
        {
            if (animator == null)
            {
                return false;
            }
        }
        return true;
    }
}
