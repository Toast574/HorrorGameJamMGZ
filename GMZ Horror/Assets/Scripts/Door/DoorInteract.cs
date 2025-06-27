using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private GameObject Interacttext;


    private void Start()
    {
        NotLookingAtDoor();
    }
    private void OnTriggerEnter(Collider other)
    {
        LookingAtDoor();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            doorAnim.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NotLookingAtDoor();
    }

    void LookingAtDoor()
    {
        Interacttext.SetActive(true);
    }

    void NotLookingAtDoor()
    {
        Interacttext.SetActive(false);
    }
}
