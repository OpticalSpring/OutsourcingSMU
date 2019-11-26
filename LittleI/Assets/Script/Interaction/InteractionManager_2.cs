using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager_2 : MonoBehaviour
{
    public GameObject foxImage;
    public GameObject backImage;
    public Vector3 nextPos;
    public Vector3 nextPos2;
    public int count;
    public bool clear;

    public GameObject[] jobImage;
    public Vector3[] jobValue;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = foxImage.transform.localPosition;
        nextPos2 = backImage.transform.localPosition;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4);
    }

    // Update is called once per frame
    void Update()
    {
        foxImage.transform.localPosition = Vector3.MoveTowards(foxImage.transform.localPosition, nextPos, Time.deltaTime * 500);
        backImage.transform.localPosition = Vector3.MoveTowards(backImage.transform.localPosition, nextPos2, Time.deltaTime * 500);
        jobImage[0].transform.localScale = Vector3.MoveTowards(jobImage[0].transform.localScale, jobValue[0], Time.deltaTime * 8);
        jobImage[1].transform.localScale = Vector3.MoveTowards(jobImage[1].transform.localScale, jobValue[1], Time.deltaTime * 5);
        jobImage[2].transform.localScale = Vector3.MoveTowards(jobImage[2].transform.localScale, jobValue[2], Time.deltaTime * 8);

        jobImage[3].transform.localScale = Vector3.MoveTowards(jobImage[3].transform.localScale, jobValue[3], Time.deltaTime * 5);
    }

    public void newPos()
    {
        count++;
        nextPos += new Vector3(100, 0, 0);
        if(count < 15)
        nextPos2 += new Vector3(-100, 0, 0);

        if(count == 5)
        {
            StartCoroutine("job1"); GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(22);
        }

        if(count == 10)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(22);
            jobValue[1] = new Vector3(1,1,1);
        }
        if (count == 15)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(22);
            jobValue[2] = new Vector3(1, 1, 1);
        }
        if (count == 20)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(22);
            jobValue[3] = new Vector3(1, 1, 1);
        }

        if (count > 30)
        {
            ClearCheck();
        }
    }

    IEnumerator job1()
    {
        jobValue[0] = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        jobValue[0] = new Vector3(0.8f, 0.8f, 0.8f);
        yield return new WaitForSeconds(0.2f);
        jobValue[0] = new Vector3(1, 1, 1);
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
        PlayerPrefs.SetInt("VideoNumber", 2);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
