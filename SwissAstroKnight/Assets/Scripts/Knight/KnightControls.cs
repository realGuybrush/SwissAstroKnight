using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : MonoBehaviour
{
    private Camera mainCam;
    private ControlKeys controls = new ControlKeys();
    private Rigidbody2D ship;
    public float velocity;
    public List<GameObject> guns = new List<GameObject>();
    public List<GameObject> systems = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        ship = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowCursor();
        CheckControlInput();
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
        if (Input.GetKeyDown(controls.dash)&&!dashing)
        {
            StartCoroutine("Dash");
        }
    }
}
