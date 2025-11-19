using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [Header("Win Condition Settings")]
    public Vector3 winPoint = new Vector3(2.15f, 1.24f, -1.64f); // Target position
    public float winDistance = 2.0f; // Distance threshold to trigger win

    [Header("References")]
    public Transform player; // Assign your player transform in the Inspector

    [Header("Teleport Settings")]
    public Vector3 teleportLocation = new Vector3(10f, 1.5f, -5f); // New location to teleport player

    private bool hasWon = false;

    void Update()
    {
        // Calculate distance between player and win point
        float distanceToWin = Vector3.Distance(player.position, winPoint);

        // If close enough and not already triggered, teleport the player
        if (!hasWon && distanceToWin <= winDistance)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        hasWon = true;
        Debug.Log("You made it to the Kitchen! Teleporting...");
        TeleportPlayer();
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
