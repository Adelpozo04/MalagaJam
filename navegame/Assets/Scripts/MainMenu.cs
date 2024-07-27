using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitApp()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
            Application.Quit();
    }


}
