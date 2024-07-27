using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInputManager : MonoBehaviour
{

    public List<float> fuelCostToChange = new List<float>();    


    [SerializeField] FuelBarController fuelBarController;
    [SerializeField] InputTest inputController;

    [SerializeField] float fuelSpeendPerSecond;

    private int index = 0;


    // Update is called once per frame
    void Update()
    {
        fuelBarController.SubstractFuel(fuelSpeendPerSecond* Time.deltaTime);


        if (fuelBarController.getFuelConsumed() >= fuelCostToChange[index]) {
            index++;
            inputController.changeActionMap();
        }

    }
}
