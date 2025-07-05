using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public DialogueDisplayer dDesplayerScript;
    public DialogueData dData;
    private bool isInteractable = false, parentIsInteractable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInteractable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInteractable = false;
        }
    }
    public void CantInteract()
    {
        parentIsInteractable = false;
    }
    public void CanInteract()
    {
        parentIsInteractable = true;
    }

    public void OnButtonRegular()
    {
        if (isInteractable == true && parentIsInteractable == true)
        {
            CantInteract();
            dDesplayerScript.StartDialogue(dData);
        }
    }
}
