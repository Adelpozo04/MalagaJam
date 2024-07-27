using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour
{
    #region parameters
    protected int compLife_;
    #endregion

    #region references
    protected ShipManager myShipMng_;
    #endregion

    #region methods
    virtual public void GotHit()
    {

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //myShipMng_ = this.transform.parent.gameObject.GetComponent<ShipManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
