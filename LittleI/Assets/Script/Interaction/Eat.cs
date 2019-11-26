using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public GameObject EatObject;
    bool e;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, EatObject.transform.position) < 0.5f)
        {
            if(e == false)
            {
                e = true;
                EatObject.GetComponent<Eat>().enabled = true;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(27);
                Destroy(gameObject);
            }
        }
    }
}
