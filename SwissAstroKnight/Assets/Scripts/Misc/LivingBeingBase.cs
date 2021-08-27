using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBeingBase : MonoBehaviour
{
    public LayerMask collisions;
    public Animator anim;
    protected Characteristics health = new Characteristics();
    // Start is called before the first frame update
    void Start()
    {
        Starting();
    }

    // Update is called once per frame
    void Update()
    {
        Updating();
    }

    protected virtual void Starting() { }

    protected virtual void Updating() { }

    public void GetDamage(int damage)
    {
        if (health.health == -1)
            return;
        health.health -= damage * (int)( 100f / (100f + (float)health.armor));
        if (health.health <= 0)
        {
            if (anim != null)
            {
                anim.SetBool("End", true);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Heal(int heal)
    {
        health.health += heal;
        if (health.health > health.maxHealth)
            health.health = health.maxHealth;
    }
}
