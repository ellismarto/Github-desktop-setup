using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private Collider currentCollider;
    [SerializeField] private Collider nextCollider;
    [SerializeField] private Collider additionalCollider; // New collider field

    private void Start()
    {
        // Deactivate the next collider at the start
        if (nextCollider != null)
            nextCollider.enabled = false;

        // Deactivate the additional collider at the start
        if (additionalCollider != null)
            additionalCollider.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Deactivate current collider
            currentCollider.enabled = false;

            // Activate next collider
            if (nextCollider != null)
                nextCollider.enabled = true;

            // Activate additional collider
            if (additionalCollider != null)
                additionalCollider.enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

