using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int dataFloor;
    public int dataItem_1;
    public int dataItem_2;
    public int dataItem_3;
    public int ticket;
    public int distance;
    public float vol;
    public int tog;

    public void DataSave()
    {
        PlayerPrefs.SetInt("dataFloor", dataFloor);
        PlayerPrefs.SetInt("dataItem_1", dataItem_1);
        PlayerPrefs.SetInt("dataItem_2", dataItem_2);
        PlayerPrefs.SetInt("dataItem_3", dataItem_3);
        PlayerPrefs.SetInt("ticket", ticket);
        PlayerPrefs.SetInt("distance", distance);
        PlayerPrefs.SetFloat("vol", vol);
        PlayerPrefs.SetInt("tog", tog);
    }

    public void DataLoad()
    {
        dataFloor=PlayerPrefs.GetInt("dataFloor");
        dataItem_1=PlayerPrefs.GetInt("dataItem_1");
        dataItem_2=PlayerPrefs.GetInt("dataItem_2");
        dataItem_3=PlayerPrefs.GetInt("dataItem_3");
        ticket = PlayerPrefs.GetInt("ticket");
        distance = PlayerPrefs.GetInt("distance");
        vol = PlayerPrefs.GetFloat("vol");
        tog = PlayerPrefs.GetInt("tog");
    }
}
