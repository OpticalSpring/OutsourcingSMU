using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float dist;
    private Vector3 MouseStart;
    private Vector3 derp;
    public bool OnDrag;
    public bool popup;
    public GameObject popupPanel;
    public int popupCount;

    public GameObject[] TextBox;
    public GameObject deleteObj;
    public void OffPopup()
    {
        popup = false;
        popupPanel.SetActive(false);
        TextBox[0].SetActive(false);
        TextBox[1].SetActive(false);
        TextBox[2].SetActive(false);
        if (popupCount >= 3)
        {
            deleteObj.SetActive(false);
            PlayerPrefs.SetInt("VideoNumber", 8);
            GameObject.Find("GameEvent").GetComponent<EventManager>().GameClear();
        }
    }
    private void Update()
    {
        if (OnDrag == false) {
            if (Input.GetMouseButtonDown(0))
            {
                MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
                MouseStart.y = transform.position.y;

            }
            else if (Input.GetMouseButton(0))
            {
                var MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
                MouseMove.y = transform.position.y;
                transform.position = transform.position - (MouseMove - MouseStart);
            }
        }

        if (gameObject.transform.position.x < -13)
        {
            Vector3 newPos = gameObject.transform.position;
            newPos.x = -13f;
            gameObject.transform.position = newPos;
        }
        if (gameObject.transform.position.x >13)
        {
            Vector3 newPos = gameObject.transform.position;
            newPos.x = 13f;
            gameObject.transform.position = newPos;
        }
    }
}
