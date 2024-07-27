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
        cameraInterference.SetFloat("Clarity", 0.03f);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
