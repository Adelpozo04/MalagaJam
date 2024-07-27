using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject visualContainer;


    private bool paused = false;

    public void switchPause()
    {
        paused = !paused;
        visualContainer.SetActive(!visualContainer.activeSelf);

        Time.timeScale = paused ? 0.0f : 1.0f;
    }
    

    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
