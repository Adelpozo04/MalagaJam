using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlHelper : MonoBehaviour
{

    [SerializeField] TMP_Text textCmp;

    [SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setControl(string controlName)
    {
        if(controlName == "rightshift")
        {

        }
        else if (controlName == "leftclick")
        {


        }
        else if (controlName == "rightclick")
        {

        }
        else if (controlName == "middleclick")
        {

        }
        else if (controlName == "shift")
        {

        }
        else if (controlName == "spacebar")
        {

        }
        else if(controlName == "enter")
        {


        }
        else if (controlName == "leftarrow")
        {

        }
        else if (controlName == "rightarrow")
        {

        }
        else if (controlName == "uparrow")
        {

        }
        else if (controlName == "downarrow")
        {

        }
        else
        {
            textCmp.text = name;
            textCmp.gameObject.SetActive(true);
        }
    }
}
