using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : LivingBeingBase
{
    private bool singularityActive = false;
    private bool singularityReady = true;
    private int singularityLevel;
    private float singularityRecoveryTime, singularityRecoveryTimeMax;
    public GameObject singularityPrefab;

    public void EnableSingularity(int level)
    {
        singularityActive = level != 0;
        singularityLevel = level;
        singularityRecoveryTimeMax = 10f / level;
    }

    private void ShootSingularity()
    {
        if (singularityActive && singularityReady)
        {
            GameObject sing = GameObject.Instantiate(singularityPrefab, this.transform.position, new Quaternion());
            sing.transform.eulerAngles = rotatingPart.transform.eulerAngles;
            sing.GetComponent<Singularity>().destination = mainCam.ScreenToWorldPoint(Input.mousePosition);
            sing.GetComponent<Singularity>().destination = new Vector3(sing.GetComponent<Singularity>().destination.x, sing.GetComponent<Singularity>().destination.y, 0f);
            singularityReady = false;
        }
    }

    private void UpdateSingularity()
    {
        if (!singularityReady)
        {
            singularityRecoveryTime += Time.fixedDeltaTime;
            if (singularityRecoveryTime >= singularityRecoveryTimeMax)
            {
                singularityRecoveryTime = 0;
                singularityReady = true;
            }
        }
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        if(!singularityReady)
            singularityRecoveryTime += 0.01f * singularityLevel * singularityRecoveryTimeMax;
    }

}
