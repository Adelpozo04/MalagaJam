using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool _open;

    private void Start()
    {
        _open = false;
    }

    public void OnButtonClick()
    {
        if (!_open)
        {
            OpenMenu();
            _open = true;
        }
        else
        {
            CloseMenu();
            _open = false;
        }
    }
    
    void OpenMenu()
    {
        panel.SetActive(true);
    }
    void CloseMenu()
    {
        panel.SetActive(false);    
    }
}
