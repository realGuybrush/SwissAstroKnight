using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : MonoBehaviour
{
    bool canDash = false;
    bool dashing = false;
    float baseDash = 2.5f;
    int dashLevel = 0;
    public Dash dasher;

    public void SetDash(int level)
    {
        dashLevel = level;
        if (dashLevel == 3)
        {
            dashLevel = 4;
            canDash = true;
        }
        if (dashLevel == 0)
            canDash = false;
    }

    public IEnumerator Dash()
    {
        float koeff = baseDash*dashLevel;
        dashing = true;
        ship.velocity *= koeff;
        velocity *= koeff;
        yield return new WaitForSeconds(0.2f);
        ship.velocity /= koeff;
        velocity /= koeff;
        dashing = false;
    }
}
