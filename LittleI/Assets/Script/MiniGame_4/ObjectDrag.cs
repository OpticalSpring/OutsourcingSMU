using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    float distance = 10;
    public int type;
    public bool on;
    public GameObject[] checkPos;
    public float v1, v2, v3;

    // Update is called once per frame
    void Update()
    {
        if(on == false)
        PosCheck();
    }

    void PosCheck()
    {
        Vector3 n = gameObject.transform.position;
        n.z = 0;
        v1 = Vector3.Distance(n, checkPos[0].transform.position);
        v2 = Vector3.Distance(n, checkPos[1].transform.position);
        v3 = Vector3.Distance(n, checkPos[2].transform.position);
        switch (type)
        {
            case 0:
                if (v1 < 1)
                {
                    Next();
                }else if (v2 < 1)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(37);
                    gameObject.transform.position = Vector3.zero;
                }else if (v3 < 1)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(37);
                    gameObject.transform.position = Vector3.zero;
                }
                break;
            case 1:
                if (v2 < 1)
                {
                    Next();
                }
                else if (v1 < 1)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(37);
                    gameObject.transform.position = Vector3.zero;
                }
                else if (v3 < 1)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(37);
                    gameObject.transform.position = Vector3.zero;
                }
                break;
            case 2:
                if (v3 < 1)
                {
                    Next();
                }
                else if (v1 < 1)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(37);
                    gameObject.transform.position = Vector3.zero;
                }
                else if (v2 < 1)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(37);
                    gameObject.transform.position = Vector3.zero;
                }
                break;
        }
    }

    void Next()
    {
       
        on = true;
        gameObject.transform.parent.gameObject.GetComponent<MiniGameManager_4>().NextObject();
    }
    void OnMouseDrag()
    {
        if (on == false)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            gameObject.transform.position = newPosition;
        }
    }
}
