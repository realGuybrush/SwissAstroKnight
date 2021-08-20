using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item
{
    public int upgradeTo = -1;
    public GameObject projectile;
    public int rotation = 0;
    public float atkSpd = 1.0f;
    private bool shooting = false;

    public void Shoot(Vector3 pos, Vector3 newRotation)
    {
        if (!shooting)
        { 
            GameObject.Instantiate(projectile, pos, new Quaternion()).transform.eulerAngles = newRotation;
            StartCoroutine(Reload(pos, newRotation));
        }
    }

    private IEnumerator Reload(Vector3 pos, Vector3 newRotation)
    {
            shooting = true;
            yield return new WaitForSeconds(1f/atkSpd);
            shooting = false;
    }
}
