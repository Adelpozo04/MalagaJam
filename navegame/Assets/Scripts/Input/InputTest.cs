using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{


    public PlayerInput playerInput;

    private int currentActionMap;
    [SerializeField]  private int maxActionMaps;

    public string actionMapBaseName;

    private bool switchedThisFrame = false;

    private bool leftPressed = false;
    private bool rightPressed = false;
    private bool upPressed = false;
    private bool downPressed = false;
    private bool shootPressed = false;
    private bool inMove = false;

    public UnityEvent startShoot;
    public UnityEvent endShoot;
    public UnityEvent startMove;
    public UnityEvent endMove;

    // Start is called before the first frame update
    void Start()
    {
        currentActionMap = 1;

        string currentActionMapName = actionMapBaseName + currentActionMap;


        SwitchActionMap(currentActionMapName);
    }

    private void Update()
    {
        switchedThisFrame = false;
    }

    public void moveLeft(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            leftPressed = false;
            endMove.Invoke();
            inMove = false;
        }

        if(!context.started) return;

        if (context.started && !inMove)
        {
            startMove.Invoke();
            inMove = true;
        }

        leftPressed = true;


        //print("leftPressed");

        /*
        currentActionMap = 2;
        string currentActionMapName = actionMapBaseName + currentActionMap;

        SwitchActionMap(currentActionMapName);
        */
    }
    public void moveRight(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            rightPressed = false;
            endMove.Invoke();
            inMove = false;
        }

        if (!context.started) return;

        if (context.started && !inMove)
        {
            startMove.Invoke();
            inMove = true;
        }

        rightPressed = true;;
        //print("rightPressed");
    }
    public void moveUp(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            upPressed = false;
            endMove.Invoke();
            inMove = false;
        }

        if (!context.started) return;


        if (context.started && !inMove)
        {
            startMove.Invoke();
            inMove = true;
        }

        upPressed = true; 

        //print("upPressed");
    }
    public void moveDown(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            downPressed = false;
            endMove.Invoke();
            inMove = false;
        }

        if (!context.started) return;

        if (context.started && !inMove)
        {
            startMove.Invoke();
            inMove = true;
        }

        downPressed = true;

        //print("downPressed");
    }
    public void shoot(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            shootPressed = false;
            endShoot.Invoke();
        }



        if (!context.started) return;

        shootPressed = true;

        startShoot.Invoke();

        //print("shootPressed");
    }


    private void SwitchActionMap(string newMapName)
    {
        if (playerInput.currentActionMap.name != newMapName && !switchedThisFrame)
        {
            switchedThisFrame = true;
            playerInput.SwitchCurrentActionMap(newMapName);
            print("Action map switched to : " + newMapName);
        }
    }

    public Vector2 getDir()
    {
        var vec = new Vector2(0, 0);

        if (leftPressed) vec += new Vector2(-1, 0);
        if (rightPressed) vec += new Vector2(1, 0);
        if (upPressed) vec += new Vector2(0,1);
        if (downPressed) vec += new Vector2(0, -1);

        return vec;
    }


    public void changeActionMap()
    {
        if(currentActionMap < maxActionMaps)

        currentActionMap++;
        string currentActionMapName = actionMapBaseName + currentActionMap;

        SwitchActionMap(currentActionMapName);
    }
}
