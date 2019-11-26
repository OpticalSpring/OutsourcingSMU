using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int menuType;
    public GameObject[] menuTypeObject;
    public Vector3 pos;
    public GameObject UIObj;
    public GameObject option;

    private void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(2);
    }

    private void Update()
    {
        UIObj.transform.localPosition = Vector3.Lerp(UIObj.transform.localPosition, pos, Time.deltaTime * 3);
    }

    public void ChaneType_0()
    {
        menuType = 0;
        MenuTypeChange();
    }

    public void ChaneType_1()
    {
        menuType = 1;
        MenuTypeChange();
    }

    public void ChaneType_2()
    {
        menuType = 2;
    }

    public void OptionOpen()
    {
        option.SetActive(true);

    }

    public void OptionClose()
    {
        option.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }


    void MenuTypeChange()
    {
        switch (menuType)
        {
            case 0:
                pos = new Vector3(960, 0, 0);
                
                break;
            case 1:
                pos = new Vector3(-960, 0, 0);
                
                break;
            case 2:
                
                break;
        }
    }

    public void NewGameStart_1()
    {
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataFloor = 1;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_1 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_2 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_3 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().ticket = 1;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().distance = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataSave();
        GameStart();
    }
    public void NewGameStart_2()
    {
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataFloor = 1;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_1 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_2 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_3 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataSave();
        GameStart();
    }
    public void NewGameStart_3()
    {
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataFloor = 1;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_1 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_2 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_3 = 0;
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataSave();
        GameStart();
    }

    public void LoadGameStart()
    {
        SceneManager.LoadScene(1);
    }
    void GameStart()
    {
        SceneManager.LoadScene(3);
    }
}
