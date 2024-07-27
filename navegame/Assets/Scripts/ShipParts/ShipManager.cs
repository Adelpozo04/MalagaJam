using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipManager : MonoBehaviour
{
    #region parameters
    #endregion

    #region references
    PlayerMovement _myPlayerMovement;
    [SerializeField] private FuelBarController fuelBar;
    [SerializeField] private int fuelDamage; //La cantidad de fuel que pierdes al ser golpeado sin componente
    //Yo dir�a que cada componente te pase el da�o que vayan a sufrir, as� si un componente es golpeado demasiado sufres m�s da�o
    #endregion

    #region methods
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
    #endregion

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
