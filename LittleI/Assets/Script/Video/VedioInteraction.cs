using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VedioInteraction : MonoBehaviour
{
    public float delayTime;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delayTime > 0)
        {
            delayTime -= Time.deltaTime;
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            delayTime = 5;
        }
    }
}
