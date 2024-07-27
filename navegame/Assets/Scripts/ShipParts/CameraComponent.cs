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

    [SerializeField] private AudioClip destroyClip;
    #endregion

    #region methods
    override public void GotHit()
    {

        Debug.Log(compLife_);
        if(compLife_ == 2) {
            cameraInterference.SetFloat("_Clarity", 0.01f);
        }
        else if (compLife_ == 1)
        {
            cameraInterference.SetFloat("_Clarity", 0.04f);
        }
        else
        {
            myShipMng_.sufferDamage((compLife_ - 1) * -10);
        }
        compLife_--;
        SFXManager.instance.playSFXClip(destroyClip, transform, 1f);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        compLife_ = 2;
        cameraInterference.SetFloat("_Clarity", 0f);
        myShipMng_ = this.transform.parent.gameObject.GetComponent<ShipManager>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
