using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderWeb : MonoBehaviour
{
    public float speed;
    GameObject player;
     public  float timeValue;
    public bool dead;
    public GameObject slowUI;
    public Text slowUIText;
    // Start is called before the first frame update
    void Start()
    {
        slowUI = GameObject.Find("SlowUI_1");
        slowUIText = slowUI.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (dead == false)
        {
            if (col.CompareTag("Player"))
            {

                col.GetComponent<UnitBase>().movementSpeed = speed * 0.5f;
                slowUI.GetComponent<SpriteRenderer>().enabled = true;
                player = col.gameObject;
                GameObject.Find("GameManager").GetComponent<GameManager>().timeValue = 10;
            }
        }
    }
}
