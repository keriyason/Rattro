using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePopUp : MonoBehaviour
{
    [SerializeField] private GameObject promptUI;      // Text "Press E"
    [SerializeField] private GameObject dialoguePanel; // Popup panel/image
    private bool playerInRange = false;

    void Start()
    {
        if (promptUI != null) promptUI.SetActive(false);
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (playerInRange)
        {
            if (promptUI != null && !promptUI.activeSelf)
            {
                Debug.Log("Showing prompt UI");
                promptUI.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed: opening dialogue panel");
                if (dialoguePanel != null) dialoguePanel.SetActive(true);

                // UI interaction for FPS
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if (promptUI != null) promptUI.SetActive(false);
            }
        }
        else
        {
            if (promptUI != null && promptUI.activeSelf)
            {
                Debug.Log("Hiding prompt UI (out of range)");
                promptUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered interact range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited interact range");
            playerInRange = false;

            if (dialoguePanel != null && dialoguePanel.activeSelf)
            {
                Debug.Log("Closing dialogue panel (player left range)");
                dialoguePanel.SetActive(false);
            }
        }
    }

    // Hook this to your close button
    public void CloseDialogue()
    {
        Debug.Log("CloseDialogue clicked");
        if (dialoguePanel != null) dialoguePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

