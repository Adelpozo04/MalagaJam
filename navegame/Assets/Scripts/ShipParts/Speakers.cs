using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speakers : ShipComponent
{
    [SerializeField] private bool isRight;
    [SerializeField] private AudioClip destroyClip;

    override public void GotHit()
    {
        SFXManager.instance.playSFXClip(destroyClip, transform, 1f);
        SFXManager.instance.destroySpeaker(isRight);
    }
}
