using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialgoueBox : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel; // dialgue panel
    [SerializeField] private TMP_Text dialogueText;    // text editable in inspec
    [SerializeField] private Image characterImage;     
    [SerializeField] private Sprite characterPortrait;
    [TextArea] public string[] lines;                  // diagloue box
    private int index = 0;

    void Start()
    {
        dialoguePanel.SetActive(true);
        if (characterImage != null && characterPortrait != null)
            characterImage.sprite = characterPortrait;

        ShowLine();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // if you click your mouse it advance to the next dialouge
        {
            NextLine();
        }
    }

    private void ShowLine()
    {
        if (index < lines.Length)
        {
            dialogueText.text = lines[index];
        }
        else
        {
            EndDialogue();
        }
    }

    private void NextLine()
    {
        index++;
        ShowLine();
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}

