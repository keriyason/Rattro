using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene management

public class WinCondition : MonoBehaviour
{
    [Header("Win Condition Settings")]
    public Vector3 winPoint = new Vector3(2.15f, 1.24f, -1.64f); // Target position
    public float winDistance = 2.0f; // Distance threshold to trigger win

    [Header("References")]
    public Transform player; // Assign your player transform in the Inspector

    [Header("Scene Settings")]
    public int nextSceneIndex = 2; // Scene build index to load (Kitchen)

    private bool hasWon = false;

    void Update()
    {
        // Calculate distance between player and win point
        float distanceToWin = Vector3.Distance(player.position, winPoint);

        // If close enough and not already triggered, win the game
        if (!hasWon && distanceToWin <= winDistance)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        hasWon = true;
        Debug.Log("You made it to the Kitchen!");
        LoadSceneByIndex(nextSceneIndex);
    }

    void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(2);
    }
}
