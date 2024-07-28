using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1.0f;  
    }

    public void ExitApp()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
            Application.Quit();
    }


}
