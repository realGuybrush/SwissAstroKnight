using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoost : ShipSystem
{
    public int gunAmount = 8;
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
        transform.parent.parent.gameObject.GetComponent<KnightControls>().EnableGunBooster(Level);
        bool setGun = Level > 0 ? true : false;
        for (int i = 0; i < gunAmount; i++)
        {
            if (transform.parent.GetChild(i)?.childCount > 1)
            {
                transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(setGun);
                transform.parent.GetChild(i).GetChild(0).eulerAngles = transform.parent.GetChild(i).GetChild(1).eulerAngles;
                ChangeTransparencyOnAllSprites(transform.parent.GetChild(i).GetChild(0));
            }
        }
    }

    private void ChangeTransparencyOnAllSprites(Transform flames)
    {
        Color transp = new Color(1f, 1f, 1f, 0.61f + Level * 0.13f);
        for (int i = 0; i < flames.childCount; i++)
        {
            if(flames.GetChild(i).gameObject.GetComponent<SpriteRenderer>())//fix: how to use elvis here?
                flames.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = transp;
        }
    }
}
