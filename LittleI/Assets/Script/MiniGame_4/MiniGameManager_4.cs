using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager_4 : MonoBehaviour
{
    public int eventNumber;
    public Text uiText;
    public GameObject deleteObj;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(19);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextObject()
    {
        eventNumber++;
        if (eventNumber < 18)
        {
            gameObject.transform.GetChild(eventNumber).gameObject.SetActive(true);
            uiText.text = gameObject.transform.GetChild(eventNumber).gameObject.name;
        }
        else
        {
            PlayerPrefs.SetInt("VideoNumber", 10);
            GameObject.Find("GameEvent").GetComponent<EventManager>().GameClear();
            deleteObj.SetActive(false);
        }
    }
}
