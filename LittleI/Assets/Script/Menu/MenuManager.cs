using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int eventNumber;
    public GameObject[] setObject;
    public bool touch;
    public GameObject EBookOBJ;
    public Vector2 mPos;
    bool eb;
    public GameObject ebutton;
    public SpriteRenderer[] spr;
    public int state;
    public int state2;
    public void Res()
    {
        PlayerPrefs.SetInt("State",0);
        PlayerPrefs.SetInt("State2", 0);
    }
    private void Start()
    {
       
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(0);
        state = PlayerPrefs.GetInt("State");
        state2 = PlayerPrefs.GetInt("State2");
        if (state > 0) {
            spr[0].color = new Vector4(1, 1, 1, 1);
            spr[0].gameObject.transform.GetChild(0).gameObject.SetActive(false); }
        if (state > 1)
        {
            spr[1].color = new Vector4(1, 1, 1, 1);
            spr[1].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(state2 == 0)
        {
            state2 = 1;
            PlayerPrefs.SetInt("State2",1);
            SceneManager.LoadSceneAsync(18);
        }
        
    }

    void Update()
    {
        switch (eventNumber)
        {
            case 0:
                GamePreview();
                break;
            case 1:
                MenuSelect();
                break;
        }
        if(eb ==true) EBook(); 
    }

    void GamePreview()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Debug.Log("Complete" + hit.collider.name);
                if (hit.collider.gameObject.GetComponent<ObjectID>().ID == 0)
                {
                    MenuSet();
                }
            }

        }

    }
    void EbookSet()
    {
        setObject[0].SetActive(false);
        setObject[1].SetActive(false);
        setObject[2].SetActive(true);
        eventNumber = 1;
        eb = true;
        ebutton.SetActive(true);
    }

    void MenuSet()
    {
        setObject[0].SetActive(false);
        setObject[1].SetActive(true);
        setObject[2].SetActive(false);
        eventNumber = 1;
        eb = false;
        ebutton.SetActive(false);
    }

    void MenuSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Debug.Log("Complete" + hit.collider.name);
                switch (hit.collider.gameObject.GetComponent<ObjectID>().ID)
                {
                    case 1:
                        SceneManager.LoadSceneAsync(7);
                        PlayerPrefs.SetInt("VideoNumber", 0);
                        break;
                    case 2:
                        if(state > 0)
                        SceneManager.LoadSceneAsync(14);
                        break;
                    case 3:
                        if (state > 1)
                        {
                            SceneManager.LoadSceneAsync(7);
                            PlayerPrefs.SetInt("VideoNumber", 14);
                        }
                        break;
                    case 101:
                        GameObject.Find("Option").GetComponent<Option>().op();
                        break;
                    case 102:
                        EbookSet();
                        break;
                    case 103:
                        MenuSet();
                        break;
                }
            }

        }
    }

    void EBook()
    {
        if(Time.timeScale == 1)
        if (Input.GetMouseButtonDown(0))
        {
            touch = true;
            mPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float nextX = Input.mousePosition.x- mPos.x;
            mPos = Input.mousePosition;
            EBookOBJ.transform.position += new Vector3(nextX*0.03f, 0, 0);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touch = false; GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(24);
            }


        


        if (touch == false)
        {
            float min = 100;
            float num = 0;
            for(int i = 0; i < 10; i++)
            {
                float dis;
                dis = Mathf.Abs(EBookOBJ.transform.localPosition.x + i * 25);
                if(min > dis)
                {
                    min = dis;
                    num = i;
                }
            }
            EBookOBJ.transform.localPosition= Vector3.Lerp(EBookOBJ.transform.localPosition, new Vector3(-num * 25, 0, 0),  10* Time.deltaTime);
        }

       
    }
}
