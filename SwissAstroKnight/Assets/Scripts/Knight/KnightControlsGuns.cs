using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    private List<Gun> guns = new List<Gun>();

    private void UpdateGuns()
    {
        guns = new List<Gun>();
        for (int i = 0; i < weapons.Count; i++)
            if (weapons[i].transform.childCount > 0)
            {
                guns.Add(weapons[i].transform.GetChild(0).GetComponent<Gun>());
            }
            else
            {
                guns.Add(null);
            }
    }

    private void Shoot()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            if (guns[i] != null)
            {
                GameObject.Instantiate(guns[i].projectile[guns[i].tier], weapons[i].transform.position, new Quaternion()).transform.eulerAngles = weapons[i].transform.eulerAngles + new Vector3(0f, 0f, guns[i].rotation*45);
            }
        }
    }
}
