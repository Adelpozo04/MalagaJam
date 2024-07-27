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
