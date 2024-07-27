using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : ShipComponent
{
    #region parameters
    #endregion

    #region references
    [SerializeField]
    private Material cameraInterference;
    #endregion

    #region methods
    override public void GotHit()
    {
        if(compLife_ == 2) {
            cameraInterference.SetFloat("_Clarity", 0.01f);
        }
        else if (compLife_ == 1)
        {
            cameraInterference.SetFloat("_Clarity", 0.03f);
        }
        else
        {
            myShipMng_.sufferDamage();
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        compLife_ = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
