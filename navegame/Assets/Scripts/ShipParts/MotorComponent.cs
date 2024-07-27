using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorComponent : ShipComponent
{
    #region parameters
    [SerializeField]
    private bool right;
    #endregion

    #region references
    private PlayerMovement plMove;
    #endregion

    #region methods
    override public void GotHit()
    {
        if (compLife_ == 1)
        {
            if(right)
            {
                plMove.destroyRightMotor();
            }
            else
            {
                plMove.destroyLeftMotor();
            }
        }
        else
        {
            myShipMng_.sufferDamage((compLife_ - 1) * -20);
        }
        compLife_--;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        compLife_ = 1;
        plMove = this.transform.parent.gameObject.GetComponent<PlayerMovement>();
        myShipMng_ = this.transform.parent.gameObject.GetComponent<ShipManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}