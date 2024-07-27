using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speakers : ShipComponent
{
    [SerializeField] private bool isRight;

    override public void GotHit()
    {
        SFXManager.instance.destroySpeaker(isRight);
    }
}
