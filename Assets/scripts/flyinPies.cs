using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyinPies : MonoBehaviour
{

    public Vector3 direction;
    public float speed;

    [SerializeField] int damage;

    private float maxDistance = 5;
    private Vector3 startSpot;

    // Start is called before the first frame update
    void Start()
    {
        startSpot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed;
        if(Vector3.Distance(startSpot, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<enemyAI>().enemyHealth -= damage;
            Destroy(gameObject);
        }
    }
}
