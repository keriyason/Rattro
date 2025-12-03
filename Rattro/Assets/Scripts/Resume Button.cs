using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Assign your pause menu panel in Inspector

    // Call this from your button's OnClick event
    public void ResumeGame()
    {
        // Hide pause menu
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        // Resume time
        Time.timeScale = 1f;

        // Optionally unlock cursor if you locked it during pause
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Example: call this when pausing
    public void PauseGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

