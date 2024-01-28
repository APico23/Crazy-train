using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] float distance = .2f;
    [SerializeField] float speed = 100;
    [SerializeField] float turnSpeed = 100;
    [SerializeField] List<GameObject> segments= new List<GameObject>();
    List<GameObject> snakebody = new List<GameObject>();
    float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        makeSegment();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        manageSnakeBody();
        snakeMovement(); 
    }

    void manageSnakeBody()
    {
        if (segments.Count > 0)
        {
            makeSegment();
        }
        for (int i = 0; i < snakebody.Count; i++)
        {
            if (snakebody[i] == null)
            {
                snakebody.RemoveAt(i);
                i = i - 1;
            }
            if (snakebody.Count == 0)
                Destroy(this);
        }
    }
    void snakeMovement()
    {
        //move the head with inputs
        snakebody[0].GetComponent<Rigidbody2D>().velocity = snakebody[0].transform.right * speed * Time.deltaTime;
        if(Input.GetAxis("Horizontal")!= 0)
        {
            snakebody[0].transform.Rotate(new Vector3(0,0,-turnSpeed*Time.deltaTime * Input.GetAxis("Horizontal")));
        }
        if(snakebody.Count > 1)
        {
            for(int i = 1; i < snakebody.Count; i++)
            {
                markerManager markM = snakebody[i-1].GetComponent<markerManager>();
                snakebody[i].transform.position= markM.markerList[0].position;
                snakebody[i].transform.rotation = markM.markerList[0].rotation;
                markM.markerList.RemoveAt(0);
            }
        }
    }
    void makeSegment()
    {
        if (snakebody.Count == 0)
        {
            GameObject tmp1 = Instantiate(segments[0], transform.position, transform.rotation, transform);
            if (!tmp1.GetComponent<markerManager>())
                tmp1.AddComponent<markerManager>();
            if (!tmp1.GetComponent<Rigidbody2D>())
            {
                tmp1.AddComponent<Rigidbody2D>();
                tmp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            snakebody.Add(tmp1);
            segments.RemoveAt(0);
        }
        markerManager markM = snakebody[snakebody.Count-1].GetComponent<markerManager>();
        if(count ==0)
        {
            markM.clearMarkers();
        }
        count += Time.deltaTime;
        if(count >= distance)
        {
        GameObject tmp = Instantiate(segments[0], markM.markerList[0].position , markM.markerList[0].rotation, transform);
        if(!tmp.GetComponent<markerManager>())
            tmp.AddComponent<markerManager>();
        if(!tmp.GetComponent<Rigidbody2D>())
        {
            tmp.AddComponent<Rigidbody2D>();
            tmp.GetComponent<Rigidbody2D>().gravityScale=0;
        }
        snakebody.Add(tmp);
        segments.RemoveAt(0);
        tmp.GetComponent<markerManager>().clearMarkers();
            count = 0;
        }
    }
    public void addSegment(GameObject obj)
    {
        segments.Add(obj);
    }
}
