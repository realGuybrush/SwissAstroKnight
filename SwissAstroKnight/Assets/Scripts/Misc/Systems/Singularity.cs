using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singularity : MonoBehaviour
{
    bool active = false;
    public Vector3 destination;
    public LayerMask collisions;
    public GameObject pullerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            if (GlobalFuncs.Distance(destination, this.transform.position) < 0.1f)
            {
                Activate();
                active = true;
            }
        }
    }

    void Activate()
    {
        Projectile p = this.gameObject.GetComponent<Projectile>();
        p.collisions = collisions;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        p.anim.SetBool("Explode", true);
        GameObject.Instantiate(pullerPrefab, this.transform.position, this.transform.rotation);
    }
}
