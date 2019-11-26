using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager_9 : MonoBehaviour
{
    public GameObject[] job;
    public float logTime;
    bool d;
    public bool clear;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(11);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(43);
    }

    // Update is called once per frame
    void Update()
    {
        logTime -= Time.deltaTime;
        if (logTime > 0)
        {
            job[0].transform.position = Vector3.Lerp(job[0].transform.position, new Vector3(0, -3, 0), Time.deltaTime*2);
            job[1].transform.position = Vector3.Lerp(job[1].transform.position, new Vector3(0, -1.5f, 0), Time.deltaTime * 2);
            job[2].transform.position = Vector3.Lerp(job[2].transform.position, new Vector3(0, 0, 0), Time.deltaTime * 2);
            job[3].transform.position = Vector3.Lerp(job[3].transform.position, new Vector3(0, 3, 0), Time.deltaTime * 2);
            job[4].transform.position = Vector3.Lerp(job[4].transform.position, new Vector3(0, 5, 0), Time.deltaTime * 2);
            job[5].transform.localScale = Vector3.Lerp(job[5].transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 2);
            job[6].transform.localScale = Vector3.Lerp(job[6].transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 2);
        }
        else if (logTime <= 0 && d ==false)
        {
            d = true;
            job[5].GetComponent<SpriteAlpha>().OutAlphaChange();
            job[6].GetComponent<SpriteAlpha>().OutAlphaChange();
        }
        ClearCheck();




    }
    void ClearCheck()
    {
        if (clear == false)
        {
            int f=0;
            for(int i = 0; i < 4; i++)
            {
                if(job[i] == null)
                {
                    f++;
                }
            }
            if (f == 4)
            {
                clear = true;
                StartCoroutine("Clear");
            }
        }
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetInt("VideoNumber", 11);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
