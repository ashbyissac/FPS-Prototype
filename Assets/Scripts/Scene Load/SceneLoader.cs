using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
