using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    [SerializeField] SnakeManager snakeManager;
    Transform target;
    [SerializeField] float smoothing;
    [SerializeField] float initialCameraSize;
    float cameraSize;
    int lastSize = 0;

    private void Start()
    {
        target = snakeManager.snakebody[0].transform;
    }



    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

            if (lastSize != snakeManager.snakebody.Count)
            {
                lastSize = snakeManager.snakebody.Count;
                cameraSize = initialCameraSize + (0.2f * snakeManager.snakebody.Count);
                GetComponent<Camera>().orthographicSize = cameraSize;
            }

        }
    }


}
