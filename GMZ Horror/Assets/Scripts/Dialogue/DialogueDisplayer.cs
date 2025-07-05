using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem;

public class DialogueDisplayer : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;

    private DialogueData currentDialogue;
    private int currentLineIndex;
    private Coroutine typingCoroutine;
    // Call this function to start a dialogue
    public void StartDialogue(DialogueData dialogue)
    {
        Interactable[] interactables = FindObjectsOfType<Interactable>();
        currentDialogue = dialogue;
        currentLineIndex = 0;
        dialogueBox.SetActive(true);
        DisplayNextLine();
    }

    // Display the next line of dialogue with a typewriter effect
    public void DisplayNextLine()
    {
        Debug.Log("DisplayNextLine called. currentLineIndex: " + currentLineIndex); // Add at the start of DisplayNextLine()
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // Stop previous typing coroutine if any
            typingCoroutine = null;
        }

        if (currentLineIndex < currentDialogue.dialogueLines.Length)
        {
            StartCoroutine(StartTypingWithDelay());
        }
        else
        {
            EndDialogue();
        }
    }
    private IEnumerator StartTypingWithDelay()
    {
        yield return null; // Wait for one frame

        string lineToDisplay = currentDialogue.dialogueLines[currentLineIndex].line;
        typingCoroutine = StartCoroutine(TypeLine(lineToDisplay));
        currentLineIndex++;
    }
        // Coroutine to display text character by character
        private IEnumerator TypeLine(string line)
    {
        dialogueText.text = ""; // Clear the text field initially
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        typingCoroutine = null;
    }

    // Call this function to end the dialogue
    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        // Add any other logic here, like resuming gameplay
        StartCoroutine(waitalittle());
        
    }

    IEnumerator waitalittle()
    {
        yield return new WaitForSeconds(1f);
        Interactable[] interactables = FindObjectsOfType<Interactable>();
        foreach (Interactable interactable in interactables)
        {
            interactable.CanInteract();
        }
    }

    // Optional: Add a function to allow skipping the typing animation
    public void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = null;
        dialogueText.text = currentDialogue.dialogueLines[currentLineIndex - 1].line; // Display the full line
    }


    private void OnButtonRegular()
    {
        if (dialogueBox.activeSelf) // Example: advance on mouse click
        {
            // Check if the typing coroutine is currently active
            if (typingCoroutine != null)
            {
                // If the coroutine is still running, skip the typing animation
                SkipTyping();
            }
            else
            {
                // If the coroutine is NOT running (meaning the typewriter effect has finished),
                // display the next line of dialogue
                DisplayNextLine();
            }
        }
    }
}
