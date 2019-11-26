using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager_3 : MonoBehaviour
{
    public int eventNumber;
    public int count;
    private void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(15);
    }

    private void Update()
    {
        switch (eventNumber)
        {
            case 3:
                PlayerPrefs.SetInt("VideoNumber", 8);
                GameObject.Find("GameEvent").GetComponent<EventManager>().GameClear();
                break;
        }        
    }
}
