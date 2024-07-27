using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHelperManager : MonoBehaviour
{


    [System.Serializable]
    public struct MapActionsNames
    {
        public string left;
        public string right;
        public string up;
        public string down;
        public string shoot;
    }

    public List<MapActionsNames> mapActionsNamesList;


    [SerializeField] ControlHelper left;
    [SerializeField] ControlHelper right;
    [SerializeField] ControlHelper up;
    [SerializeField] ControlHelper down;
    [SerializeField] ControlHelper shoot;

  

    public void updateControlHelpers(int index)
    {
        if(index >= mapActionsNamesList.Count)
        {
            print("error index out of bounds");
        }

        left.setControl(mapActionsNamesList[index].left);
        right.setControl(mapActionsNamesList[index].right);
        up.setControl(mapActionsNamesList[index].up);
        down.setControl(mapActionsNamesList[index].down);
        shoot.setControl(mapActionsNamesList[index].shoot);    
    }


    private void Start()
    {
        updateControlHelpers(0);    
    }
}
