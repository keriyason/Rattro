using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string StartingScene = "Scene Transitions";

    public void StartGame()
    {
        SceneManager.LoadScene("Scene Transitions");
    }
}

