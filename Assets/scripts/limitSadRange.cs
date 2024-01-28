using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitSadRange : MonoBehaviour
{

    private float maxDistance = 5;
    private Vector3 startSpot;

    void Start()
    {
        startSpot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (getDistance(startSpot, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    float getDistance(Vector3 start, Vector3 current)
    {
        float ex = Mathf.Abs(start.x - current.x);
        float why = Mathf.Abs(start.y - current.y);
        return Mathf.Sqrt(Mathf.Pow(ex, 2) + Mathf.Pow(why, 2));
    }
}
