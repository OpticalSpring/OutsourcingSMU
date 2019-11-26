using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager_3 : MonoBehaviour
{
    public int eventNumber;
    public GameObject[] hand;
    public bool clear;
    public GameObject[] Bullet;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(5);
    }

    // Update is called once per frame
    void Update()
    {
        if(clear == false)
        {
            if(eventNumber >= 30)
            {
                clear = true;
                GameClear();
            }
        }
    }


    public void Touch()
    {
        eventNumber++;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(23);
        if (eventNumber % 2 == 0)
        {
            hand[0].SetActive(true);
            hand[1].SetActive(false);
        }
        else
        {
            hand[0].SetActive(false);
            hand[1].SetActive(true);
        }
        GameObject temp = Instantiate(Bullet[Random.Range(0,8)]);
        temp.transform.position = new Vector3(0, -5, 0);
    }

    void GameClear()
    {
        PlayerPrefs.SetInt("VideoNumber", 3);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
