using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNone2 : MonoBehaviour
{

    public GameObject endPos;
    public float dis;
    public bool tt;
    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(endPos.transform.position, gameObject.transform.position);
        if (dis < 1 && tt == false)
        {
            tt = true;
            GetComponent<InteractionDrag>().interaction = false;
            GameObject.Find("InteractionManager").GetComponent<InteractionManager_6>().gok++;
        }
    }
}
