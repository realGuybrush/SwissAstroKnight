using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileDOT : Projectile
{
    public float timeGapBetweenDamages = 0.2f;
    List<(Collider2D, bool beingDamaged)> damagedEntities = new List<(Collider2D, bool)>();

    private void Update()
    {
        for (int i = 0; i < damagedEntities.Count; i++)
        {
            if (damagedEntities[i].Item1 != null)
            {
                StartCoroutine(Damage(i));
            }
        }
        if (damagedEntities.Count == damagedEntities.Where(i => i.beingDamaged == false).ToList().Count)
            damagedEntities.Clear();
    }

    IEnumerator Damage(int index)
    {
        if (!damagedEntities[index].beingDamaged)
        {
            damagedEntities[index] = (damagedEntities[index].Item1, true);
            damagedEntities[index].Item1.gameObject.GetComponent<LivingBeingBase>().GetDamage(damage);
            yield return new WaitForSeconds(0.2f);
            damagedEntities[index] = (damagedEntities[index].Item1, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        damagedEntities.Add((collision, false));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int index = damagedEntities.IndexOf((collision, true));
        if (index == -1)
        {
            index = damagedEntities.IndexOf((collision, false));
        }
        if (index == -1) return;
        damagedEntities[index] = (null, damagedEntities[index].beingDamaged);
    }
}
