using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float lifetime = 5f;
    public float velocity = 10f;
    public int damage = 10;
    void Start()
    {
        projectile.velocity = velocity * transform.up;//new Vector2(Mathf.Cos(transform.eulerAngles.z), Mathf.Sin(transform.eulerAngles.z));
        StartCoroutine("Live");
    }

    public IEnumerator Live()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        BasicEnemyMovement enemy = collision.gameObject.GetComponent<BasicEnemyMovement>();
        if (enemy != null)
        {
           Destroy(enemy.gameObject);
            //enemy.GetDamage(damage);
        }
    }
}
