using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisions; 
    public Rigidbody2D projectile;
    public float lifetime = 5f;
    public float velocity = 10f;
    public int damage = 10;
    public Animator anim;
    void Start()
    {
        projectile.velocity = velocity * transform.up;
        StartCoroutine("Live");
    }

    public IEnumerator Live()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisions == (collisions | (1 << collision.gameObject.layer)))
        {
            collision.gameObject.GetComponent<LivingBeingBase>()?.GetDamage(damage);
            if (anim == null)
                Destroy(this.gameObject);
            else
                anim.SetBool("End", true);
        }
    }
}
