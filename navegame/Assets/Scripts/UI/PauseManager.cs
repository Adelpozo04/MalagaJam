using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject visualContainer;


    private bool paused = false;

    float lastTimeScale;
    public void switchPause()
    {
        if(!paused) { lastTimeScale = Time.timeScale; } 

        paused = !paused;
        visualContainer.SetActive(!visualContainer.activeSelf);

        Time.timeScale = paused ? 0.0f : lastTimeScale;
    }
    

    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
