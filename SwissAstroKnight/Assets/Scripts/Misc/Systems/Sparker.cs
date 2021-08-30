using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparker : ShipSystem
{
    public CircleCollider2D circle;
    public GameObject idle;
    public List<Spark> sparks;
    float radius = 0.5f;
    List<Collider2D> collisions = new List<Collider2D>();
    List<(LivingBeingBase, bool)> entities = new List<(LivingBeingBase, bool)>();
    // Start is called before the first frame update
    void Start()
    {
        radius = circle.radius;
    }

    // Update is called once per frame
    void Update()
    {
        ManageSparks();
    }

    protected override void OnLevelChanged()
    {
        circle.radius = radius * (1f + Level/1.5f);
        if (Level > 0)
        {
            for (int i = 0; i < sparks.Count; i++)
            {
                sparks[i].gameObject.SetActive(i <= (sparks.Count*Level) / 3);
                sparks[i].maxSize = new Vector2(radius * Level / 1.5f, radius * Level / 1.5f);
            }
        }
        else
        {
            for (int i = 0; i < sparks.Count; i++)
            {
                sparks[i].gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collisions.Contains(collision))
        {
            idle.SetActive(false);
            entities.Add((collision.gameObject.GetComponent<LivingBeingBase>(), false));
            if (entities[entities.Count - 1].Item1 != null)
            {
                collisions.Add(collision);
            }
            else
            {
                entities.RemoveAt(entities.Count - 1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collisions.Contains(collision))
        {
            DisconnectSpark(collision);
            entities.RemoveAt(collisions.IndexOf(collision));
            collisions.Remove(collision);
        }
        if (collisions.Count == 0)
        {
            idle.SetActive(true);
        }
    }

    private void ManageSparks()
    {
        for (int i = 0; i < collisions.Count; i++)
        {
            if (!entities[i].Item2)
            {
                entities[i] = (entities[i].Item1, true);
                ConnectSpark(collisions[i]);
            }
        }
    }

    private void ConnectSpark(Collider2D coll)
    {
        for (int i = 0; i < sparks.Count; i++)
        {
            if (!sparks[i].striking)
            {
                sparks[i].Connect(coll);
                break;
            }
        }
    }

    private void DisconnectSpark(Collider2D coll)
    {
        for (int i = 0; i < sparks.Count; i++)
        {
            if (sparks[i].connection == coll)
                sparks[i].Disconnect();
        }
    }
}
