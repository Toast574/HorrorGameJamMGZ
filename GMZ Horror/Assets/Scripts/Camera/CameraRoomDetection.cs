using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraRoomDetection : MonoBehaviour
{
    [Header("Camera")]
    [Tooltip("Same Camera for both")]
    [SerializeField] private GameObject camr;
    [Tooltip("Same Camera for both")]
    [SerializeField] private Camera CameraZ;


    [Header("Audio")]
    [Tooltip("Select if ur using audio")]
    [SerializeField] private bool soundInRoom;
    [Tooltip("Set the sound ur using")]
    [SerializeField] private AudioSource roomSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RoomEntered();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RoomExited();
        }
    }

    void RoomEntered()
    {
        camr.SetActive(true);
    }

    void RoomExited()
    {
        camr.SetActive(false);
    }
}
