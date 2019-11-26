using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionManager_1 : MonoBehaviour
{
    public bool[] button;
    public bool clear;
    public GameObject foxImage;
    public GameObject backImage;
    public Image[] image;
    public Image[] buttonImage;
    public Sprite[] spr;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(2);
    }

    // Update is called once per frame
    void Update()
    {
        
            ClearCheck();
        
        if(clear == true)
        {
            foxImage.transform.localPosition = Vector3.MoveTowards(foxImage.transform.localPosition, new Vector3(870, -140, 0), Time.deltaTime * 500);
        }
    }

    public void ButtonOn_0()
    {
        button[0] = true;
        buttonImage[0].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        image[0].sprite = spr[0];
    }
    public void ButtonOn_1()
    {
        button[1] = true;
        buttonImage[1].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        image[1].sprite = spr[1];
    }
    public void ButtonOn_2()
    {
        button[2] = true;
        buttonImage[2].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        image[2].sprite = spr[2];
    }

    void ClearCheck()
    {
        if (clear == false)
        {
            bool check = false;
            for (int i = 0; i < 3; i++)
            {
                if (button[i] == false)
                {
                    check = true;
                }
            }
            if (check == false)
            {
                clear = true;
                StartCoroutine("Clear");
            }
        }
    }

    IEnumerator Clear()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(3);
        yield return new WaitForSeconds(5f);
        PlayerPrefs.SetInt("VideoNumber", 1);

        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
