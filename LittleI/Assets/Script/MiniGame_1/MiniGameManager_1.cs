using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager_1 : MonoBehaviour
{
    public GameObject[] handObject;
    public SpriteRenderer backGround;
    public Sprite[] backImage;
    public GameObject[] otherObject = new GameObject[8];
    public int otherObjectCount;
    public int eventNumber;
    public GameObject endObject;
    public float endImageRotateTime;
    public float endImageRotateDegree;
    public GameObject effect;
    public Text uiText;
    public float timeOut;
    public GameObject[] deleteObj;
    // Start is called before the first frame update
    void Start()
    {
        timeOut = 20;
        //GameStartSet();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(13);
    }

    // Update is called once per frame
    void Update()
    {
        switch (eventNumber)
        {
            case 0:
                GamePreview();
                break;
            case 1:
                Ray();
                TimeOut();
                break;
        }
        
    }

    void TimeOut()
    {
        if (timeOut > 0)
        {
            timeOut -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("GameEvent").GetComponent<EventManager>().GameOver();
        }
        uiText.text = (int)timeOut +"";
    }

    void GamePreview()
    {
        if(handObject[0].transform.position.x > 12)
        {
            backGround.sprite = backImage[2];
            Destroy(handObject[0]);
            Destroy(handObject[1]);
            GameStartSet();
        }
        else if (handObject[0].transform.position.x > 10)
        {
            backGround.sprite = backImage[1];

        }
        else if (handObject[0].transform.position.x > 8)
        {
            backGround.sprite = backImage[0];
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
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(34);
                Debug.Log("Complete" + hit.collider.name);
                if (hit.collider.gameObject.GetComponent<ObjectID>().ID == 2)
                {
                    GameEndSet();
                }
                Destroy(hit.collider.gameObject);
                Instantiate(effect, hit.transform.position, hit.transform.rotation);
                
            }

        }
    }

    void GameStartSet()
    {
        Vector3 randomPos = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        Instantiate(otherObject[8], randomPos, gameObject.transform.rotation);
        int q = 0;
        for(int i = 0; i < otherObjectCount; i++)
        {
            randomPos = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
            GameObject temp = Instantiate(otherObject[q], randomPos, gameObject.transform.rotation);
            temp.transform.parent = gameObject.transform.GetChild(0);
                q++;
            if(q > 7)
            {
                q = 0;
            }
        }
        eventNumber = 1;
    }

    void GameEndSet()
    {
        eventNumber++;
        deleteObj[0].SetActive(false);
        deleteObj[1].SetActive(false);
        endObject.SetActive(true);
        StartCoroutine("RotateBackground");
    }

   IEnumerator RotateBackground()
    {
        
        while(endImageRotateTime > 0)
        {
            endImageRotateTime -= Time.deltaTime;
            endObject.transform.GetChild(0).Rotate(Vector3.forward * Time.deltaTime * endImageRotateDegree);
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Find("GameEvent").GetComponent<EventManager>().GameClear();
    }

    public void Next()
    {
        PlayerPrefs.SetInt("VideoNumber", 4);
        GameObject.Find("GameEvent").GetComponent<EventManager>().NextScene();
    }
}
