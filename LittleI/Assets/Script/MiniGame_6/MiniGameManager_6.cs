using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager_6 : MonoBehaviour
{
    public int eventNumber;
    public GameObject back;
    public GameObject Qobj;
    public GameObject Aobj;
    public GameObject bPos;
    public GameObject Button;
    public GameObject animal;
    public bool checking;
    public AudioSource ss;
    public GameObject allforone;
    


    private void Start()
    {
        StartCoroutine("BSet");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(21);
    }

    private void Update()
    {

    }

    void TrueCheck(int input)
    {
        if (checking == false)
        {
            if (eventNumber == input)
            {
                StartCoroutine(True2Check(input));
                checking = true;
                if(eventNumber < 8)
                    StartCoroutine("OK");
                else
                {
                    StartCoroutine("GameClear");
                }
            }
            else
            {
                StartCoroutine(FalseCheck(input));
            }
        }
    }
    IEnumerator BSet() 
    {
        back.transform.GetChild(0).gameObject.SetActive(true);
        back.transform.GetChild(1).gameObject.SetActive(false);
        back.transform.GetChild(2).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        back.transform.GetChild(1).gameObject.SetActive(true);
        back.transform.GetChild(0).gameObject.SetActive(false);
        back.transform.GetChild(2).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        back.transform.GetChild(2).gameObject.SetActive(true);
        back.transform.GetChild(1).gameObject.SetActive(false);
        back.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        allforone.SetActive(true);
        if (eventNumber == -1)
        {
            eventNumber = 0;
            NewSet();
        }
        else
        {
            NextLoad();

        }
    }

    IEnumerator BOut()
    {
        back.transform.GetChild(2).gameObject.SetActive(true);
        back.transform.GetChild(1).gameObject.SetActive(false);
        back.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        back.transform.GetChild(1).gameObject.SetActive(true);
        back.transform.GetChild(0).gameObject.SetActive(false);
        back.transform.GetChild(2).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        back.transform.GetChild(0).gameObject.SetActive(true);
        back.transform.GetChild(1).gameObject.SetActive(false);
        back.transform.GetChild(2).gameObject.SetActive(false);
    }

    IEnumerator GameClear()
    {
        animal.transform.GetChild(eventNumber).gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        Qobj.transform.GetChild(eventNumber).gameObject.SetActive(false);
        Aobj.transform.GetChild(eventNumber).gameObject.SetActive(true); yield return new WaitForSeconds(0.5f);
        StartCoroutine("BOut");
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("GameEvent").GetComponent<EventManager>().GameClear();
        PlayerPrefs.SetInt("VideoNumber", 15);
        
    }
    IEnumerator OK()
    {
        animal.transform.GetChild(eventNumber).gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        Qobj.transform.GetChild(eventNumber).gameObject.SetActive(false);
        Aobj.transform.GetChild(eventNumber).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        StartCoroutine("BOut");
        allforone.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine("BSet");
        
    }
    IEnumerator True2Check(int input)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(36);
        //Button.transform.GetChild(input).gameObject.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
        Button.transform.GetChild(input).GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Button.transform.GetChild(input).GetChild(0).gameObject.SetActive(false);
        //Button.transform.GetChild(input).gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
    }
    IEnumerator FalseCheck(int input)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(35);
        //Button.transform.GetChild(input).gameObject.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
        Button.transform.GetChild(input).GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Button.transform.GetChild(input).GetChild(1).gameObject.SetActive(false);
        //Button.transform.GetChild(input).gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
    }
    void NewSet()
    {
        animal.transform.GetChild(eventNumber).gameObject.SetActive(true);
        Qobj.transform.GetChild(eventNumber).gameObject.SetActive(true);
        int pos1 = -1, pos2 = -1, pos3 = -1, pos4 = -1, pos5 = -1;
        pos1 = (int)Mathf.Floor(Random.Range(0, 2.9f)); Debug.Log("Pos1" + pos1);
        while (true)
        {
            pos2 = (int)Mathf.Floor(Random.Range(0, 8.9f));
            if (eventNumber != pos2)
            {
                Debug.Log("Pos2" + pos2);
                break;
            }
        }
        while (true)
        {
            pos3 = (int)Mathf.Floor(Random.Range(0, 8.9f));
            if (eventNumber != pos3)
            {
                if (pos2 != pos3)
                {
                    Debug.Log("Pos3" + pos3);
                    break;
                }
            }
        }
        while (true)
        {
            pos4 = (int)Mathf.Floor(Random.Range(0, 2.9f));
            if (pos1 != pos4)
            {
                Debug.Log("Pos4" + pos4);
                break;
            }
        }
        while (true)
        {
            pos5 = (int)Mathf.Floor(Random.Range(0, 2.9f));
            if (pos1 != pos5)
            {
                if (pos4 != pos5)
                {
                    Debug.Log("Pos5" + pos5);
                    break;
                }
            }
        }


        Button.transform.GetChild(eventNumber).transform.position = bPos.transform.GetChild(pos1).position;
        Button.transform.GetChild(pos2).transform.position = bPos.transform.GetChild(pos4).position;
        Button.transform.GetChild(pos3).transform.position = bPos.transform.GetChild(pos5).position;
    }

    void NextLoad()
    {
        for(int i =0; i < 9; i++)
        {
            Button.transform.GetChild(i).position = new Vector3(0, -10000, 0)
;        }
        animal.transform.GetChild(eventNumber).gameObject.SetActive(false);
        Aobj.transform.GetChild(eventNumber).gameObject.SetActive(false);

        eventNumber++;

        NewSet();

        checking = false;
    }

    public void b0()
    {
        TrueCheck(0);
    }
    public void b1()
    {
        TrueCheck(1);
    }
    public void b2()
    {
        TrueCheck(2);
    }
    public void b3()
    {
        TrueCheck(3);
    }
    public void b4()
    {
        TrueCheck(4);
    }
    public void b5()
    {
        TrueCheck(5);
    }
    public void b6()
    {
        TrueCheck(6);
    }
    public void b7()
    {
        TrueCheck(7);
    }
    public void b8()
    {
        TrueCheck(8);
    }

    public void ss2()
    {
        ss.Play();
    }
}
