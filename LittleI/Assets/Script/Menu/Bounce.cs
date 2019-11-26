using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Vector3 oldPos;
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (up==true)
        {
            if(Vector3.Distance(gameObject.transform.position, oldPos+new Vector3(0, 0.5f, 0)) < 0.3)
            {
                up = false;
            }
            gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, oldPos + new Vector3(0, 0.5f, 0), Time.deltaTime * 0.5f);
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, oldPos + new Vector3(0, -0.5f, 0)) < 0.3)
            {
                up = true;
            }
            gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, oldPos + new Vector3(0, -0.5f, 0), Time.deltaTime * 0.5f);
        }
    }
}
