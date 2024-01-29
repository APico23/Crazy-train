using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleTimer : MonoBehaviour
{

    [SerializeField] float stopShieldWait;
    [SerializeField] float abilityWait;
    [SerializeField] SpriteRenderer bubble;
    private float countdown = 0;
    private bool isGuarding = false;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            if (isGuarding)
            {
                countdown = abilityWait;
                bubble.enabled = false;
                isGuarding= false;
                gameObject.tag = "Train"; 
            }
            else
            {
                countdown = stopShieldWait;
                bubble.enabled = true;
                isGuarding= true;
                gameObject.tag = "Untagged";
            }
        }
    }
}
