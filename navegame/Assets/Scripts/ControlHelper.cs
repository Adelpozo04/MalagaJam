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
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);
        }
        else if (controlName == "leftclick")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

        }
        else if (controlName == "rightclick")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);
        }
        else if (controlName == "middleclick")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

        }
        else if (controlName == "shift")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);


        }
        else if (controlName == "spacebar")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

        }
        else if(controlName == "enter")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);


        }
        else if (controlName == "leftarrow")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

            image.sprite = SpritesContainer.Instance.leftClick;

        }
        else if (controlName == "rightarrow")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

            

        }
        else if (controlName == "uparrow")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);


        }
        else if (controlName == "downarrow")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);


        }
        else
        {
            textCmp.text = controlName;
            textCmp.gameObject.SetActive(true);
        }
    }
}
