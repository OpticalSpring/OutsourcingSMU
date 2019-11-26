using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager_10 : MonoBehaviour
{
    public GameObject maskObject;
    public GameObject ers;
    public Vector3 spawnPosition;

    public GameObject[] job;
    public int eventNumber;
    public GameObject[] massss;
    public int d;
    public bool dd;
    public GameObject inB;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(12);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(28);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(44);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(spawnPosition, ers.transform.position) > 2)
        {
            spawnPosition = ers.transform.position;
            GameObject mask = Instantiate(maskObject, spawnPosition, ers.transform.rotation);
            massss[d] = mask;
            d++;
        }

        if (d > 30 && dd == false)
        {
            dd = true;
            StartCoroutine("NextWave");
        }

        if (Input.GetMouseButton(0))
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().Sound[44].GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().Sound[44].GetComponent<AudioSource>().volume = 0;
        }
    }

    public void NextButton()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundStop(eventNumber + 27);
        inB.SetActive(false);
        job[eventNumber].SetActive(false);
        eventNumber++;
        if (eventNumber == 7)
        {
            PlayerPrefs.SetInt("VideoNumber", 12);
            GetComponent<EventManager>().NextScene();
        }
        else
        {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(eventNumber+27);

        }
        job[eventNumber].SetActive(true);
        for (int i = 0; i < d; i++)
        {
            Destroy(massss[i]);
        }
        d = 0;
        dd = false;
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(2f);
        inB.SetActive(true);
    }
}
