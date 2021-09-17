using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : LivingBeingBase
{
    private Camera mainCam;
    private ControlKeys controls = new ControlKeys();
    private Rigidbody2D ship;
    public float velocity;
    public List<GameObject> systems = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        ship = transform.GetComponent<Rigidbody2D>(); 
        UpdateGuns();
    }

    // Update is called once per frame
    void Update()
    {
        FollowCursor();
        CheckControlInput();
        if(AllNulls())
            UpdateGuns();
        StartCoroutine("CheckHealth");
    }

    private void FixedUpdate()
    {
        UpdateSingularity();
    }

    bool AllNulls()
    {
        for(int i=0; i< guns.Count; i++)
            if(guns[i] != null)
                return false;
        return true;
    }

    private void CheckControlInput()
    {
        if (Input.GetKey(controls.forward))
        {
            ship.velocity = new Vector2(ship.velocity.x, velocity);
        }
        if (Input.GetKeyUp(controls.forward))
        {
            ship.velocity = new Vector2(ship.velocity.x, 0.0f);
        }
        if (Input.GetKey(controls.backward))
        {
            ship.velocity = new Vector2(ship.velocity.x, -velocity);
        }
        if (Input.GetKeyUp(controls.backward))
        {
            ship.velocity = new Vector2(ship.velocity.x, 0.0f);
        }
        if (Input.GetKey(controls.leftward))
        {
            ship.velocity = new Vector2(-velocity, ship.velocity.y);
        }
        if (Input.GetKeyUp(controls.leftward))
        {
            ship.velocity = new Vector2(0.0f, ship.velocity.y);
        }
        if (Input.GetKey(controls.rightward))
        {
            ship.velocity = new Vector2(velocity, ship.velocity.y);
        }
        if (Input.GetKeyUp(controls.rightward))
        {
            ship.velocity = new Vector2(0.0f, ship.velocity.y);
        }
        if (Input.GetKeyDown(controls.dash) && !dashing && canDash)
        {
            //IEnumerator cor = dasher.ShootDash(ship.velocity);
            //StartCoroutine(cor);
            IEnumerator cor = dasherSignaller.Dashing(ship.velocity);
            StartCoroutine(cor);
            StartCoroutine("Dash");
        }
        if (Input.GetKey(controls.atk1))
        {
            Shoot();
        }
        if (Input.GetKey(controls.atk2))
        {
            ShootSingularity();
        }
    }
}
