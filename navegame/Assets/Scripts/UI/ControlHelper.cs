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

    public void setControl(string controlName,float scaleMultiplier)
    {
        if(controlName == "rightshift")
        {
            //textCmp.gameObject.SetActive(false);
            //image.gameObject.SetActive(true);

            textCmp.gameObject.SetActive(true);
            image.gameObject.SetActive(false);

            textCmp.fontSize = 70;
            textCmp.text = "R \nSHIFT";

        }
        else if (controlName == "leftclick")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

            image.sprite = SpritesContainer.Instance.leftClick;


        }
        else if (controlName == "rightclick")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

            image.sprite = SpritesContainer.Instance.rightClick;

        }
        else if (controlName == "middleclick")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

            image.sprite = SpritesContainer.Instance.middleClick;


        }
        else if (controlName == "shift")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);


        }
        else if (controlName == "spacebar")
        {
            //textCmp.gameObject.SetActive(false);
            //image.gameObject.SetActive(true);
            textCmp.gameObject.SetActive(true);
            image.gameObject.SetActive(false);

            textCmp.text = "SPACE";
            textCmp.fontSize = 68;

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

            image.sprite = SpritesContainer.Instance.leftArrow;

        }
        else if (controlName == "rightarrow")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);


            image.sprite = SpritesContainer.Instance.rightArrow;

        }
        else if (controlName == "uparrow")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

            image.sprite = SpritesContainer.Instance.upArrow;

        }
        else if (controlName == "downarrow")
        {
            textCmp.gameObject.SetActive(false);
            image.gameObject.SetActive(true);

            image.sprite = SpritesContainer.Instance.downArrow;

        }
        else
        {
            image.gameObject.SetActive(false);

            textCmp.text = controlName;
            textCmp.gameObject.SetActive(true);

            textCmp.fontSize = 150;

        }

        textCmp.fontSize = textCmp.fontSize * scaleMultiplier;
    }
}
