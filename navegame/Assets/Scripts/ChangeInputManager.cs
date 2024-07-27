using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInputManager : MonoBehaviour
{

    public List<float> fuelCostToChange = new List<float>();

    [SerializeField] private ControlHelperManager controlHelperManager;

    
    [SerializeField] InputTest inputController;

    [SerializeField] float fuelSpeendPerSecond;

    [SerializeField] WarningChangeManager warningChangeManager;
    private int index = 0;

    public int getIndex() {  return index; }    
    // Update is called once per frame
    void Update()
    {
        FuelBarController.Instance.SubstractFuel(fuelSpeendPerSecond* Time.deltaTime);


        if (index < fuelCostToChange.Count && FuelBarController.Instance.getFuelConsumed() >= fuelCostToChange[index]) {

            warningChangeManager.StartTransition();
            index++;
           
        }

    }

    public void updateInput()
    {
        inputController.changeActionMap();
        controlHelperManager.updateControlHelpers(index);
    }
}
