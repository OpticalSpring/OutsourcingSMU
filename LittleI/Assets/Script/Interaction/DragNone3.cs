using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNone3 : MonoBehaviour
{
    public Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, oldPos) > 2.5f)
        {
            GetComponent<InteractionDrag>().interaction = false;
            StartCoroutine("DelayClear");
        }
    }

    IEnumerator DelayClear()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("InteractionManager").GetComponent<InteractionManager_8>().GameClear();
    }
}
