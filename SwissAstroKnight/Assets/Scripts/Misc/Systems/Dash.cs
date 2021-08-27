using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ShipSystem
{
    public Transform actualDasher;
    float transpA = 50.0f;
    public Animator a;

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
        transform.parent.parent.gameObject.GetComponent<KnightControls>().SetDash(Level);
        transpA = 25.0f + 25.0f * Level;
    }

    public IEnumerator Dashing(Vector3 velocity)
    {
        float velVector = Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y);
        if (velVector != 0)
        {
            actualDasher.eulerAngles = new Vector3(0f, 0f, -90f + Mathf.Acos(velocity.x / velVector) * Mathf.Rad2Deg * (velocity.y > 0 ? 1f : -1f));
            a.SetBool("Dash", true);
            yield return new WaitForSeconds(0.2f);
            a.SetBool("Dash", false);
        }
    }
}
