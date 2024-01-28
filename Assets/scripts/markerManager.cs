using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerManager : MonoBehaviour
{
    public class Marker { 
        public Vector3 position;
        public Quaternion rotation;

        public Marker(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }

    }
    public List<Marker> markerList = new List<Marker>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateMarkerList();
    }
    public void updateMarkerList()
    {
        markerList.Add(new Marker(transform.position, transform.rotation));
    }
    public void clearMarkers()
    {
        markerList.Clear();
        markerList.Add(new Marker(transform.position, transform.rotation)); 
    }
}
