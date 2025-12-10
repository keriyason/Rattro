using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [Header("Win Condition Settings")]
    public Transform winPoint; // player goes to this GOs point
    public float winDistance = 2.0f; //area threshhold for teleport distance

    [Header("References")]
    public Transform player;

    [Header("Teleport Settings")]
    public Transform teleportTarget; // teleport location
    private bool isInZone = false;

    void Update()
    {
        if (player == null || winPoint == null) return;

        float distanceToWin = Vector3.Distance(player.position, winPoint.position);

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
            isInZone = false;
        }
    }

    void TeleportPlayer()
    {
        if (teleportTarget == null)
        {
            Debug.LogError("Teleport target not assigned in Inspector!");
            return;
        }

        player.position = teleportTarget.position;

       
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}





