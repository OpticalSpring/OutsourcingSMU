using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
