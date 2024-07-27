using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningChangeManager : MonoBehaviour
{
    [SerializeField] ChangeInputManager changeInputManager;

    [SerializeField] ControlHelperManager info;
    [SerializeField] ControlHelperManager antiguo;
    [SerializeField] ControlHelperManager nuevo;



    private void Start()
    {
        antiguo.updateControlHelpers(info.mapActionsNamesList[changeInputManager.getIndex()]);
        nuevo.updateControlHelpers(info.mapActionsNamesList[changeInputManager.getIndex()+1]);
        
        antiguo.updateControlHelpers(info.mapActionsNamesList[1]);
        nuevo.updateControlHelpers(info.mapActionsNamesList[2]);
    }
}
