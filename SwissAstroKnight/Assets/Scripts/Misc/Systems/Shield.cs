using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ShipSystem
{
    public Transform backPart;
    public Transform body;
    public Transform ship;
    public LivingBeingBase shield;
    public Animator anim;
    public float recoveryTime = 10f;
    bool recovering = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("End")&&!recovering)
        {
            StartCoroutine("Recover");
        }
        body.transform.position = ship.transform.position;
    }

    protected override void OnLevelChanged()
    {
        for (int i = 0; i < backPart.childCount; i++)
        {
            transform.parent.parent.GetComponent<LivingBeingBase>().EnableShield();
            backPart.GetChild(i).gameObject.SetActive((i+1) == Level);
            body.gameObject.SetActive(Level > 0);
            recoveryTime = 20f - Level * 5f;
        }
    }

    IEnumerator Recover()
    {
        backPart.gameObject.SetActive(false);
        recovering = true;
        transform.parent.parent.GetComponent<LivingBeingBase>().DisableShield();
        yield return new WaitForSeconds(recoveryTime);
        backPart.gameObject.SetActive(true);
        shield.Heal();
        transform.parent.parent.GetComponent<LivingBeingBase>().EnableShield();
        anim.SetBool("End", false);
        recovering = false;
    }
}
