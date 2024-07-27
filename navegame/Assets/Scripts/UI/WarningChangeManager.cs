using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningChangeManager : MonoBehaviour
{
    public float transitionTime;
    public float inGameTime;

    [SerializeField] GameObject visualContainer;

    [SerializeField] ChangeInputManager changeInputManager;

    [SerializeField] ControlHelperManager info;
    [SerializeField] ControlHelperManager antiguo;
    [SerializeField] ControlHelperManager nuevo;

    [SerializeField] TMP_Text countDown;

    [SerializeField] GameObject visualContainerControlHelper;


    private float elapsedTime;

    bool inTransition = false;

    bool controlHelperWasActive = false;

    private void Update()
    {
        if (inTransition)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime < inGameTime / 3)
            {
                countDown.text = "3";
            }
            else if(elapsedTime < inGameTime*2 / 3)
            {
                countDown.text = "2";
            }
            else if(elapsedTime < inGameTime*3 / 3)
            {
                countDown.text = "1";
            }
            else if(elapsedTime > inGameTime)
            {
                inTransition = false;
                visualContainer.SetActive(false);
                Time.timeScale = 1.0f;

                visualContainerControlHelper.SetActive(controlHelperWasActive);

                changeInputManager.updateInput();
            }


        }


    }


    public void StartTransition()
    {
        Time.timeScale = inGameTime/transitionTime;

        visualContainer.SetActive(true);

        elapsedTime = 0;

        inTransition = true;

        controlHelperWasActive = visualContainerControlHelper.activeInHierarchy;

        visualContainerControlHelper.SetActive(false);  

        antiguo.updateControlHelpers(info.mapActionsNamesList[changeInputManager.getIndex()]);
        nuevo.updateControlHelpers(info.mapActionsNamesList[changeInputManager.getIndex()+1]);
    }

}
