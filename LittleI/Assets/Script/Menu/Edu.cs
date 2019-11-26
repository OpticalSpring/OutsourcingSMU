using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edu : MonoBehaviour
{
    public GameObject popupObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopupOpen()
    {
        popupObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void PopupClose()
    {
        popupObject.SetActive(false);
        Time.timeScale = 1;
    }
}
