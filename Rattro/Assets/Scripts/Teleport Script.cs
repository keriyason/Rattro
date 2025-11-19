using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [Header("Win Condition Settings")]
    public Vector3 winPoint = new Vector3(2.15f, 1.24f, -1.64f); // Target position
    public float winDistance = 2.0f; // Distance threshold to trigger teleport

    [Header("References")]
    public Transform player; // Assign your player transform in the Inspector

    [Header("Teleport Settings")]
    public Vector3 teleportLocation = new Vector3(10f, 1.5f, -5f); // New location to teleport player

    private bool isInZone = false;

    void Update()
    {
        float distanceToWin = Vector3.Distance(player.position, winPoint);

        if (distanceToWin <= winDistance)
        {
            if (!isInZone)
            {
                isInZone = true;
                Debug.Log("You made it to the Kitchen! Teleporting...");
                TeleportPlayer();
            }
        }
        else
        {
            isInZone = false; // Reset when player leaves the zone
        }
    }

    void TeleportPlayer()
    {
        player.position = teleportLocation;

        // Optional: reset velocity if using Rigidbody
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}




