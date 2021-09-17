using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition((1/GlobalFuncs.Distance(this.transform.position, collision.transform.position))*(this.transform.position-collision.transform.position), collision.transform.position);
    }
}
