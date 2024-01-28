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
    SnakeManager snakeM;
    // Start is called before the first frame update
    void Start()
    {
        snakeM = GetComponent<SnakeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
