using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : MonoBehaviour
{
    Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FollowCursor();
    }
}
