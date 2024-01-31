using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour
{

    public List<Color> colors;
    float timeElapsed;
    int cIndex;
    public Text sr;

    private void Start()
    {
        timeElapsed = 0;
        cIndex = 0;
    }


    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        Color newColor = Color.Lerp(sr.color, colors[cIndex], 0.01f);
        sr.color = newColor;
        if (timeElapsed > 0.5)
        {
            cIndex++;
            if (cIndex >= colors.Count)
            {
                cIndex = 0;
            }
            timeElapsed = 0;
        }
    }
}
