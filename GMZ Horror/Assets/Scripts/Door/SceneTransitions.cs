using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public Transform player, targetpos;
    IEnumerator teleport()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.35f);
        player.position = targetpos.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(teleport());
        }
    }
}
