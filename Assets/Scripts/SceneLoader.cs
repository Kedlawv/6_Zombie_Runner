using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void reloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
