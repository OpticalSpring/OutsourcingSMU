using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager_4 : MonoBehaviour
{
    public int gok;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(6);
    }

    // Update is called once per frame
    void Update()
    {
        ClearCheck();
    }

    void ClearCheck()
    {
        if(gok== 6)
        {
            gok++;
            Clear();
        }
    }

    void Clear()
    {
        PlayerPrefs.SetInt("VideoNumber", 5);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
