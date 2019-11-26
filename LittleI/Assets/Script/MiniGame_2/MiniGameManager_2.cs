using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager_2 : MonoBehaviour
{
    public int eventNumber;
    public GameObject[] otherObject = new GameObject[4];
    public int otherObjectCount;
    public int percent;
    public Text uiText;

    public GameObject endObject;
    public float endImageRotateTime;
    public float endImageRotateDegree;
    public GameObject[] deleteObj;
    // Start is called before the first frame update
    void Start()
    {
        GameStartSet();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(14);
    }

    // Update is called once per frame
    void Update()
    {
        switch (eventNumber)
        {
            case 0:
                //GamePreview();
                break;
            case 1:
                break;
        }
        if (percent > 100) percent = 100;
        uiText.text = percent + "%";
        if(percent >= 100)
        {
            GameObject.Find("GameEvent").GetComponent<EventManager>().GameOver();
        }
    }
    public void Clear()
    {
        endObject.SetActive(true);
        deleteObj[0].SetActive(false);
        deleteObj[1].SetActive(false);
        StartCoroutine("RotateBackground");
        if(PlayerPrefs.GetInt("State")==0)
        PlayerPrefs.SetInt("State", 1);
    }
    void GameStartSet()
    {
        Vector3 randomPos = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        Instantiate(otherObject[4], randomPos, gameObject.transform.rotation);
        int q = 0;
        for (int i = 0; i < otherObjectCount; i++)
        {
            randomPos = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
            GameObject temp = Instantiate(otherObject[q], randomPos, gameObject.transform.rotation);
            temp.transform.parent = gameObject.transform.GetChild(0);
            //temp.GetComponent<SpriteRenderer>().sortingOrder = i+2;
            q++;
            if (q > 3)
            {
                q = 0;
            }
        }
        eventNumber = 1;
    }
    IEnumerator RotateBackground()
    {

        while (endImageRotateTime > 0)
        {
            endImageRotateTime -= Time.deltaTime;
            endObject.transform.GetChild(0).Rotate(Vector3.forward * Time.deltaTime * endImageRotateDegree);
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Find("GameEvent").GetComponent<EventManager>().GameClear();
    }
}
