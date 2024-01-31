using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleTimer : MonoBehaviour
{

    [SerializeField] float stopShieldWait;
    [SerializeField] float abilityWait;
    [SerializeField] SpriteRenderer bubble;
    private float countdown = 0;
    public bool isBubble;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            if (isBubble)
            {

                countdown = abilityWait;
                bubble.enabled = false;
                isBubble = false;
                gameObject.tag = "Train"; 
            }
            else
            {
                countdown = stopShieldWait;
                bubble.enabled = true;
                isBubble = true;
                gameObject.tag = "Untagged";
            }
        }
    }
}
