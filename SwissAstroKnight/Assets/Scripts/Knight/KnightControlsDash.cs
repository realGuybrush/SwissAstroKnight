using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : MonoBehaviour
{
    bool dashing = false;

    public IEnumerator Dash()
    {
        dashing = true;
        ship.velocity *= 10.0f;
        velocity *= 10.0f;
        yield return new WaitForSeconds(0.2f);
        ship.velocity /= 10.0f;
        velocity /= 10.0f;
        dashing = false;
    }
}
