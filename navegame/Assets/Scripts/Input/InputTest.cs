using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{


    public PlayerInput playerInput;
    public string actionMapName;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveLeft(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        print("leftPressed");

        //print(playerInput.currentActionMap.name);
            
        if(playerInput.currentActionMap.name != actionMapName)  
        {
            playerInput.SwitchCurrentActionMap(actionMapName);
            //print("changedMap");
            //print(playerInput.currentActionMap.name);
            //playerInput.currentActionMap.Enable();  
        }
    }



}
