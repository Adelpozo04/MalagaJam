using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCurrentControls : MonoBehaviour
{
    [SerializeField] GameObject visualContainer;

    public void switchShowCurrentControls()
    {
        visualContainer.SetActive(!visualContainer.activeSelf);
    }   
}
