using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicMaker : MonoBehaviour
{
    public List<AudioClip> clipList = new List<AudioClip>();
    AudioSource audioSource;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        var count = clipList.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = clipList[i];
            clipList[i] = clipList[r];
            clipList[r] = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clipList[index];
            index += 1;
            if (index >= clipList.Count)
            {
                index = 0;
            }
            audioSource.Play();
        }
    }
}
