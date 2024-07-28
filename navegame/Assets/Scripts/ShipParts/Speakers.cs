using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speakers : ShipComponent
{
    [SerializeField] private bool isRight;
    [SerializeField] private AudioClip destroyClip;

    override public void GotHit()
    {
        if (compLife_ == 1)
        {
            SFXManager.instance.playSFXClip(destroyClip, transform, 1f);
            //GetComponent<Animator>().SetTrigger("Destroy");
            SFXManager.instance.playSFXClip(destroyClip, transform, 1f);
            SFXManager.instance.destroySpeaker(isRight);
        }
        else
        {
            myShipMng_.sufferDamage((compLife_ - 1) * -10);
        }
        compLife_--;
    }

    void Start()
    {
        compLife_ = 1;
        myShipMng_ = this.transform.parent.gameObject.GetComponent<ShipManager>();
    }
}
