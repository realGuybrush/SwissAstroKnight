using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystem : MonoBehaviour
{
    private int level = 0;
    public int Level { get => level; set { level = value; OnLevelChanged(); } }
    private bool active { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnLevelChanged()
    {
        
    }
}
