using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuQuit : MonoBehaviour
{
    public void LEAVE()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
