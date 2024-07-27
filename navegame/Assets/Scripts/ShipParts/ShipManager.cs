using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipManager : MonoBehaviour
{
    PlayerMovement _myPlayerMovement;
    [SerializeField] private FuelBarController fuelBar;
    [SerializeField] private int fuelDamage; //La cantidad de fuel que pierdes al ser golpeado sin componente
    
    private void destroyRightMotor()
    {
        _myPlayerMovement.destroyRightMotor();
    }
    
    private void destroyLeftMotor()
    {
        _myPlayerMovement.destroyLeftMotor();
    }

    public void sufferDamage()
    {
        fuelBar.SubstractFuel(fuelDamage);
    }

    // Start is called before the first frame update
    void Start()
    {
        _myPlayerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
