using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PauseActive()
    {
        Time.timeScale = 0;
    }
    
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
