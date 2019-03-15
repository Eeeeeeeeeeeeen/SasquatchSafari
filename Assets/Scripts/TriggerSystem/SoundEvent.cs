using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : TriggerEvent
{
    public override void Fire()
    {
        this.GetComponent<AudioSource>().Play();
    }
}
