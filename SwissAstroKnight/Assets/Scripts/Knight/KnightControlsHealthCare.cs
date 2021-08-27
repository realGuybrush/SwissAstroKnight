using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : LivingBeingBase
{
    public int healAmountPer1 = 5;
    public float freq = 1f;
    bool canHeal = false;
    bool healing = false;
    public Heal healer;
    public void EnableHeal(int level)
    {
        canHeal = (level != 0);
        freq = 1f/level;
    }

    private IEnumerator CheckHealth()
    {
        if (canHeal && !FullHealth())
        {
            if (!healing)
            {
                healing = true;
                Heal(healAmountPer1);
                yield return new WaitForSeconds(freq);
                healing = false;
            }
        }
    }

    private bool FullHealth()
    {
        healer.SetHealAnimation(health.health != health.maxHealth);
        return health.health == health.maxHealth;
    }
}
