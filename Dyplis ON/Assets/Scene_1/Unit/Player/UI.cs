using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject[] Heart_Object;
    Slider[] Heart = new Slider[4];
    // Start is called before the first frame update

    Vector3[] originPos = new Vector3[4];

    public float _amount; public float _duration; int obj;
   public float timer;


    public GameObject invenObject;
    bool invenSet;
    public GameObject optionObject;
    bool optionSet;

    public GameObject[] roomLightUI;
    public Text[] Reward;
    void Start()
    {
        for (int i = 0; i < 4; i++) {
            Heart[i] = Heart_Object[i].GetComponent<Slider>();
            originPos[i] = Heart_Object[i].GetComponent<RectTransform>().anchoredPosition;
                }
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataLoad();
        int hp = Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_2;
        HeartUpdate(12 + 4 * hp);
        GameObject.Find("Player").GetComponent<UnitBase>().HP = 12 + 4 * hp;

        if (Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_1 == 1)
        {
            roomLightUI[0].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            roomLightUI[1].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
        //if(Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_2 == 1)
        //Reward[0].text = "HP증가"; if (Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_1 == 1)
        //    Reward[1].text = "천리안";
        string str = "";
        if (Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_1 == 1) str += " 천리안";
        if (Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_2 == 1) str += " 정기점검";
        if (Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_3 >= 1) str += " 룰렛티켓";
        Reward[0].text = str;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionSet)
            {
                optionObject.SetActive(false);
                optionSet = false;
                Time.timeScale = 1;
            }
            else
            {
                optionObject.SetActive(true);
                optionSet = true;
                Time.timeScale = 0;
            }
        }

        Shake();
    }

    public void HeartUpdate(float HP)
    {
        timer = 0;
        int nObject = (int)HP / 4;
        int nHP = (int)HP % 4;
        switch (nObject)
        {
            case 0:
                HP_Update(0, nHP);
                HP_Update(1, 0);
                HP_Update(2, 0);
                HP_Update(3, 0);
                obj = 0;
                break;
            case 1:
                HP_Update(0, 4);
                HP_Update(1, nHP);
                HP_Update(2, 0);
                HP_Update(3, 0);
                obj = 1;
                break;
            case 2:
                HP_Update(0, 4);
                HP_Update(1, 4);
                HP_Update(2, nHP);
                HP_Update(3, 0);
                obj = 2;
                break;
            case 3:
                HP_Update(0, 4);
                HP_Update(1, 4);
                HP_Update(2, 4);
                HP_Update(3, nHP);
                obj = 3;
                break;
        }
    }
    void HP_Update(int i,int j)
    {
        Heart[i].value = 0.25f * j;
    }

    void Shake()
    {
        if (timer <= _duration)
        {
            Heart_Object[obj].GetComponent<RectTransform>().anchoredPosition
               = (Vector3)Random.insideUnitCircle * _amount + originPos[obj];

            timer += Time.deltaTime;
        }else
        Heart_Object[obj].GetComponent<RectTransform>().anchoredPosition = originPos[obj];

    }

    public void OptionClose()
    {
        optionObject.SetActive(false);
        optionSet = false;
        Time.timeScale = 1;
    }

    public void Title()
    {
        SceneManager.LoadSceneAsync(0); Time.timeScale = 1;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataSave();
    }

    public void Exit()
    {
        Application.Quit(); Time.timeScale = 1;
    }
}
