using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitScene()
    {
        Application.Quit();
    }
}
