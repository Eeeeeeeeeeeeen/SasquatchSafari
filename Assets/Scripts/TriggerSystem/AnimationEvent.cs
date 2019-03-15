using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : TriggerEvent
{
    public AnimationClip Animation;

    public override void Fire()
    {
        var animator = this.GetComponent<Animator>();
        animator.Play(Animation.name);
    }
}
