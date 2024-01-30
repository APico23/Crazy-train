using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBall : MonoBehaviour
{

    [SerializeField] int damage;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyAI>().enemyHealth -= damage;
        }
    }
}
