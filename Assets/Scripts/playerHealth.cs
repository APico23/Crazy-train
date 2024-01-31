using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public bool bubble;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if (gameObject.GetComponentInChildren<bubbleTimer>() != null )
        {
            bubble = gameObject.GetComponentInChildren<bubbleTimer>().isBubble;
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("Lose Screen");
        }
    }
}
