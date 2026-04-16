using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuFunctions : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("StartingLevel");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
