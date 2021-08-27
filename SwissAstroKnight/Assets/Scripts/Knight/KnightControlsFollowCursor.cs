using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KnightControls : LivingBeingBase
{
    public GameObject rotatingPart;
    private void FollowCursor()
    {
        float dX, dY;
        float gipotenuza;
        float preBeta;
        dX = mainCam.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        dY = mainCam.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
        gipotenuza = (float)Mathf.Sqrt(dX * dX + dY * dY);
        preBeta = (float)(Mathf.Rad2Deg * Mathf.Asin(dY / gipotenuza));
        if (dX < 0)
            preBeta = Mathf.Sign(preBeta) * 180 - preBeta;
        preBeta -= 90;
        rotatingPart.transform.eulerAngles = new Vector3(0.0f, 0.0f, preBeta);
    }
}
