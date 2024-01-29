using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingTrainsDynamically : MonoBehaviour
{
    [SerializeField] GameObject engine;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject sad;
    [SerializeField] GameObject pie;
    [SerializeField] GameObject gaping;
    [SerializeField] GameObject juggle;
    public SnakeManager snakeM;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Train")
        {
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    snakeM.addSegment(fish); 
                    break;
                case 1:
                    snakeM.addSegment(sad);
                    break;
                case 2:
                    snakeM.addSegment(pie);
                    break;
                case 3: 
                    snakeM.addSegment(gaping);
                    break;
                case 4:
                    snakeM.addSegment(juggle);
                    break;
                
            }
            Destroy(gameObject);

        }
    }
}
