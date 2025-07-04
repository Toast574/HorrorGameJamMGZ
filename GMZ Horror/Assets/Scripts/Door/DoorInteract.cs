using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    public Transform player, targetpos;

    void teleport()
    {
        doorAnim.SetTrigger("open"); 
        player.position = targetpos.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                player.position = targetpos.position;
                teleport();
            }
        }
    }
}
