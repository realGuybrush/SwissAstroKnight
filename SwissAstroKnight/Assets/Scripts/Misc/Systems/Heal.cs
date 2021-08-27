using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : ShipSystem
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnLevelChanged()
    {
        transform.parent.parent.gameObject.GetComponent<KnightControls>().EnableHeal(Level);
        anim.SetFloat("Level", Level);
    }

    public void SetHealAnimation(bool active)
    {
        anim.SetBool("Healing", active);
    }
}
