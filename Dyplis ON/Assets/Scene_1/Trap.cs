using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage;
    GameObject player;
    public float timeValue;
    public float timeValue2;
    public bool dead;
    public GameObject slowUI;
    // Start is called before the first frame update
    void Start()
    {
        slowUI = GameObject.Find("SlowUI_2");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider col)
    {
        if (dead == false)
        {
            if (col.CompareTag("Player"))
            {
                player = col.gameObject;
                player.GetComponent<UnitBase>().HP -= 1;
                player.GetComponent<PlayerCtl>().Hit();
                //col.GetComponent<UnitBase>().movementSpeed = speed * 0.5f;

                slowUI.GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("GameManager").GetComponent<GameManager>().timeValue3 = 12;
                GameObject.Find("GameManager").GetComponent<GameManager>().timeValue2 = 3;
            }
        }
    }
}
