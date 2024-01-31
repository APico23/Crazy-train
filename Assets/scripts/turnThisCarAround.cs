using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnThisCarAround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            gameObject.GetComponentInParent<Transform>().Rotate(0, 0, 180);
        }
    }
}
