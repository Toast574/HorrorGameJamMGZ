using UnityEngine;
using System.Collections;
using TMPro; // Use TextMeshPro for better text rendering

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
            Debug.Log("First");
        }

        if (currentLineIndex < currentDialogue.dialogueLines.Length)
        {
            string lineToDisplay = currentDialogue.dialogueLines[currentLineIndex].line;
            typingCoroutine = StartCoroutine(TypeLine(lineToDisplay));
            currentLineIndex++;
            Debug.Log("Second");
        }
        else
        {
            EndDialogue();
            Debug.Log("Third");
        }
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
    }

    // Call this function to end the dialogue
    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        // Add any other logic here, like resuming gameplay
    }

    // Optional: Add a function to allow skipping the typing animation
    public void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        dialogueText.text = currentDialogue.dialogueLines[currentLineIndex - 1].line; // Display the full line
    }

    // Optional: Handle player input to advance dialogue
    private void Update()
    {
        if (dialogueBox.activeSelf && Input.GetMouseButtonDown(0)) // Example: advance on mouse click
        {
            Debug.Log("Click Detected");
            // Check if the typing coroutine is currently active
            if (typingCoroutine != null)
            {
                // If the coroutine is still running, skip the typing animation
                SkipTyping();
                Debug.Log("Skipped typing");
            }
            else
            {
                // If the coroutine is NOT running (meaning the typewriter effect has finished),
                // display the next line of dialogue
                DisplayNextLine();
                Debug.Log("Displaying Next line called");
            }
        }
    }
}
