using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    public bool striking = false;
    public Collider2D connection;
    public GameObject actualSpark;
    public Vector2 maxSize = new Vector2(1f, 1f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (striking)
        {
            FollowTarget();
        }
    }

    public void Connect(Collider2D col)
    {
        connection = col;
        striking = true;
        SparkSize(maxSize);
    }

    public void Disconnect()
    {
        connection = null;
        striking = false;
        SparkSize(new Vector2(0f, 0f));
    }

    private void FollowTarget()
    {
        if (connection != null)
        {
            float dX, dY;
            float gipotenuza;
            float preBeta;
            dX = connection.transform.position.x - this.transform.position.x;
            dY = connection.transform.position.y - this.transform.position.y;
            gipotenuza = (float)Mathf.Sqrt(dX * dX + dY * dY);
            preBeta = (float)(Mathf.Rad2Deg * Mathf.Asin(dY / gipotenuza));
            if (dX < 0)
                preBeta = Mathf.Sign(preBeta) * 180 - preBeta;
            preBeta -= 90;
            this.transform.eulerAngles = new Vector3(0.0f, 0.0f, preBeta);

            float dist = GlobalFuncs.Distance(actualSpark.transform.position, connection.transform.position);
            if (dist < maxSize.y)
            {
                SparkSize(maxSize*(dist/maxSize.y));
            }
        }
        else
        {
            striking = false;
        }
    }

    private void SparkSize(Vector2 size)
    {
        actualSpark.transform.localScale = size;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == connection)
        {
            Disconnect();
        }
    }
}
