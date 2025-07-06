using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerMC : MonoBehaviour
{
    [SerializeField] private float TimelineLength;
    [SerializeField] private string SceneName;
    void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(TimelineLength);
        SceneManager.LoadScene(SceneName);
    }
}
