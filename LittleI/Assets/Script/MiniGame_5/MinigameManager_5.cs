using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager_5 : MonoBehaviour
{
    public int rabbitCount; public bool clear;
    public GameObject endObj;
    public GameObject deleteObj;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(20);
    }

    // Update is called once per frame
    void Update()
    {
        Ray();

        if (rabbitCount >= 15 && clear ==false)
        {
            clear = true;
            GameObject.Find("GameEvent").GetComponent<EventManager>().GameClear();
            deleteObj.SetActive(false);
            PlayerPrefs.SetInt("VideoNumber", 13);

            if (PlayerPrefs.GetInt("State") == 1)
                PlayerPrefs.SetInt("State", 2);
        }
    }
    void Ray()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Debug.Log("Complete" + hit.collider.name);
                if (hit.collider.gameObject.GetComponent<Rabbit>().die == false)
                {
                    hit.collider.gameObject.GetComponent<Rabbit>().Die();
                    rabbitCount++;
                }
            }

        }
    }
    public void Clear()
    {
        PlayerPrefs.SetInt("VideoNumber", 13);
        if (PlayerPrefs.GetInt("State") == 1)
            PlayerPrefs.SetInt("State", 2);
        GetComponent<EventManager>().NextScene();
    }
}
