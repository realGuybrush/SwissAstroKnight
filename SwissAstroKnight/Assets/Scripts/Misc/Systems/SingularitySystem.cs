using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingularitySystem : ShipSystem
{
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
        transform.parent.parent.gameObject.GetComponent<KnightControls>().EnableSingularity(Level);
    }
}
