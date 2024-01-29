using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findEnemy : MonoBehaviour
{

    public GameObject enemy;
    public bool isSearching = false;
    [SerializeField] GameObject pie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (isSearching == true)
            {
                isSearching = false;
                enemy = collision.gameObject;
                gameObject.GetComponent<CircleCollider2D>().radius = 0;
                GameObject newPie = Instantiate(pie, transform.position, transform.rotation);
                flyinPies pieScript = newPie.GetComponent<flyinPies>();
                pieScript.direction = Vector3.Normalize(enemy.transform.position - transform.position);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isSearching == true)
        {
            gameObject.GetComponent<CircleCollider2D>().radius += .1f;
        }
    }
}
