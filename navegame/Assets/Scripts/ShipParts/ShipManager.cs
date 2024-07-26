using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    PlayerMovement _myPlayerMovement;

    private void destroyRightMotor()
    {
        _myPlayerMovement.destroyRightMotor();
    }

    private void destroyLeftMotor()
    {
        _myPlayerMovement.destroyLeftMotor();
    }

    // Start is called before the first frame update
    void Start()
    {
        _myPlayerMovement.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
