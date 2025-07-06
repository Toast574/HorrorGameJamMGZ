using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private bool isInteractable = false, parentIsInteractable = true;
    [SerializeField] private string sceneName;
    public Animator fadeAnim;

    private void Start()
    {
        StartCoroutine(StartDoorDelay());
    }
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
        Debug.Log("ButtonPressed");
        if (isInteractable == true && parentIsInteractable == true)
        {
            Debug.Log("LoadScene");
            CantInteract();
            StartCoroutine(loadsceney());
        }
    }

    IEnumerator StartDoorDelay()
    {
        CantInteract();
        yield return new WaitForSeconds(1.3f);
        CanInteract();
    }
    IEnumerator loadsceney()
    {
        fadeAnim.SetTrigger("fadeout");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(sceneName);
    }
}
