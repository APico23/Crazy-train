using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toGapeorNotToGape : MonoBehaviour
{

    [SerializeField] float stopGapeWait;
    [SerializeField] float abilityWait;
    private float countdown = 0;
    private bool isGaping = false;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            if (isGaping)
            {
                countdown = abilityWait;
                gameObject.GetComponent<CircleCollider2D>().enabled= false;
                isGaping = false;
            }
            else
            {
                countdown = stopGapeWait;
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
                isGaping = true;
            }
        }
    }
}
