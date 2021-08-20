using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedExplosion : ShipSystem
{
    public Animator anim;
    protected override void OnLevelChanged()
    {
        anim?.SetInteger("level", Level);
    }
}
