using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI library
using DialogueEditor;

public class ConversationStarter2 : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    public Text exitText; // Reference to the UI text element

    void Start()
    {
        // Ensure the exit text is initially hidden
        exitText.gameObject.SetActive(false);
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
        Cursor.lockState = CursorLockMode.Locked;
        exitText.gameObject.SetActive(true); // Display the UI text
        StartCoroutine(HideText()); // Hide the UI text after a delay
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(7f); // Adjust the delay as needed
        exitText.gameObject.SetActive(false); // Hide the UI text
    }
}
