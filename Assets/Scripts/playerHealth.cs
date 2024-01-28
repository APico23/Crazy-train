using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

}
