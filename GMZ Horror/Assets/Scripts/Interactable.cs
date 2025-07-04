using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public DialogueDisplayer dDesplayerScript;
    public DialogueData dData;
    public KeyCode interactKey = KeyCode.E;

    private void Start()
    {
       /// dDesplayerScript.StartDialogue(dData);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(interactKey))
            {
               dDesplayerScript.StartDialogue(dData);
            }
        }
    }
}
