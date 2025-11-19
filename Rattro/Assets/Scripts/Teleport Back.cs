using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportBack : MonoBehaviour
{
    [Header("Win Condition Settings")]
    public Vector3 winPoint = new Vector3(2.15f, 1.24f, -1.64f);
    public float winDistance = 2.0f;

    [Header("References")]
    public Transform player;
    public GameObject interactPromptUI;

    [Header("Teleport Settings")]
    public Vector3 teleportLocation = new Vector3(10f, 1.5f, -5f);

    [Header("Input Settings")]
    public KeyCode interactKey = KeyCode.E;

    private bool isInZone = false;

    void Update()
    {
        float distanceToWin = Vector3.Distance(player.position, winPoint);

        if (distanceToWin <= winDistance)
        {
            if (!isInZone)
            {
                isInZone = true;
                if (interactPromptUI != null)
                    interactPromptUI.SetActive(true);
            }

            if (Input.GetKeyDown(interactKey))
            {
                TeleportPlayer();
            }
        }
        else
        {
            if (isInZone)
            {
                isInZone = false;
                if (interactPromptUI != null)
                    interactPromptUI.SetActive(false);
            }
        }
    }

    void TeleportPlayer()
    {
        Debug.Log("You pressed E near the Kitchen! Teleporting...");
        player.position = teleportLocation;

        if (interactPromptUI != null)
            interactPromptUI.SetActive(false);

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

