using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemyAI : MonoBehaviour
{

    //EnemyStats
    public int enemyHealth;
    [SerializeField] int enemyMaxHealth;
    [SerializeField] float enemySpeed;
    [SerializeField] int enemyDamage;

    //Player Target
    public GameObject target;
    public playerHealth playerH;

    //Gape information
    private bool fear = false;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;
        // target assign here
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToMove = target.transform.position - transform.position;

        directionToMove = directionToMove.normalized * Time.deltaTime * enemySpeed;
        
        //Now we add our direction to our current position. We are going to clamp the vector here to make sure we don't go past our target destination
        float maxDistance = Vector3.Distance(transform.position, target.transform.position);
        if (fear == false)
        {
            transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Train")
        {
            //Reduce Player Health
            // if (collision.gameObject."name of script".isShielded)
            playerH.health -= enemyDamage;
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Gaper")
        {
            fear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gaper")
        {
            fear = false;
        }
    }

}
