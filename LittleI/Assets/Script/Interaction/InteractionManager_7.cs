using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager_7 : MonoBehaviour
{
    public GameObject foxImage;
    public GameObject backImage;
    public Vector3 nextPos;
    public Vector3 nextPos2;
    public int count;
    public bool clear;

    public GameObject[] jobImage;
    public Vector3[] jobValue;
    public GameObject[] jobImage2;
    public Vector3[] jobValue2;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = foxImage.transform.localPosition;
        nextPos2 = backImage.transform.localPosition;
        for (int i = 0; i < 4; i++)
        {
            jobValue2[i] = jobImage2[i].transform.localPosition;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(9);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(41);
    }

    // Update is called once per frame
    void Update()
    {
        foxImage.transform.localPosition = Vector3.MoveTowards(foxImage.transform.localPosition, nextPos, Time.deltaTime * 500);
        backImage.transform.localPosition = Vector3.MoveTowards(backImage.transform.localPosition, nextPos2, Time.deltaTime * 500);
        for (int i = 0; i < 12; i++)
        {
            jobImage[i].transform.localScale = Vector3.MoveTowards(jobImage[i].transform.localScale, jobValue[i], Time.deltaTime * 8);
        }
        for (int i = 0; i < 6; i++)
        {
            jobImage2[i].transform.localPosition = Vector3.MoveTowards(jobImage2[i].transform.localPosition, jobValue2[i], Time.deltaTime * 500);
        }
    }

    public void newPos()
    {
        count++;
        nextPos += new Vector3(100, 0, 0);
        if (count < 20)
            nextPos2 += new Vector3(-100, 0, 0);
        
        if(count < 12)
        {
            jobValue[count-1] = new Vector3(1, 1, 1);
        }

        if (count == 2)
        {
            jobValue2[0] = jobImage2[0].transform.localPosition+ new Vector3(-200, 400, 0);
        }
        if (count == 3)
        {
            jobValue2[1] = jobImage2[1].transform.localPosition + new Vector3(200, 400, 0);
        }
        if (count == 6)
        {
            jobValue2[2] = jobImage2[2].transform.localPosition + new Vector3(-200, 400, 0);

        }
        if (count == 7)
        {
            jobValue2[3] = jobImage2[3].transform.localPosition + new Vector3(200, 400, 0);
        }
        if (count == 10)
        {
            jobValue2[4] = jobImage2[4].transform.localPosition + new Vector3(-200, 400, 0);

        }
        if (count == 11)
        {
            jobValue2[5] = jobImage2[5].transform.localPosition + new Vector3(200, 400, 0);
        }

        if (count > 35)
        {
            ClearCheck();
        }
    }
    
    void ClearCheck()
    {
        if (clear == false)
        {
            clear = true;
            StartCoroutine("Clear");
        }
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetInt("VideoNumber", 7);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
