using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerMovement _myPlayerMovement;
    PlayerInput _myplayerInput;

    bool _interacting;

    // Start is called before the first frame update
    void Start()
    {
        _myPlayerMovement = GetComponent<PlayerMovement>();
        _myplayerInput = GetComponent<PlayerInput>();
    }

    public bool isInteracting() 
    { 
        return _interacting;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = _myplayerInput.actions["Move"].ReadValue<Vector2>();

        direction.Normalize();
        Debug.Log(direction);
        _myPlayerMovement.SetDirection(direction);

    }
}