using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureInteraction : MonoBehaviour
{
    public bool On;
    GameObject cursor;
    public GameObject popupPanel;
    public string textMessage;
    public Text uiText;
    public GameObject[] TextBox;
    public int BoxNum;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    {
        if (On == false && Camera.main.GetComponent<BackgroundMove>().popup == false)
        {
            if (Vector3.Distance(gameObject.transform.position, cursor.transform.position) < 2)
            {
                popupPanel.SetActive(true);
                TextBox[BoxNum].SetActive(true);
                On = true;
                Camera.main.GetComponent<BackgroundMove>().popupCount++;
                Camera.main.GetComponent<BackgroundMove>().popup = true;
            }
        }
    }
}
