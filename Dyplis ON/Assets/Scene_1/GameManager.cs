using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int floorNumber;
    public int roomNumber;
    public GameObject player;
    public GameObject[] Mob;
    public GameObject[] Obstacle;
    public GameObject mapSptire;
    public GameObject miniMapSptireObject;
    public Sprite[] miniMapSptire;
    public bool roomClear;
    public GameObject[] roomMob;
    public GameObject[] roomObstacle;
    public GameObject roomObstacleGroups;
    public GameObject[] boss;
    int ri = 0;
    public int ro = 0;
    public Text roomNumberText;
    public int mapType;
    public GameObject mapPos;
    public GameObject prevDoor;
    public GameObject nextDoor;
    public Transform[] doorPos;
    public int range;
    public GameObject[] slowUI;
    public GameObject spotLight;
    public Text[] slowText;
    public float timeValue;
    public float timeValue2;
    public float timeValue3;
    public float timeValue4;
    public Text timeCheck;
    public GameObject rullet;
    public Vector3 sp;
    public int mapType222;

    private void Awake()
    {
        
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataLoad();
    }
    private void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(0);
        floorNumber = Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataFloor;
        Screen.SetResolution(Screen.width, Screen.width * 9 / 16, true);
        newMap();
        newRoom();
    }

    void Update()
    {
        TimeCheck();
        Slow1(); 
            Slow2();
            roomClear = true;
            for (int i = 0; i < roomNumber; i++)
            {
                if(roomMob[i] != null)
                {
                    roomClear = false;
                }
            }
    }

    void newRoom()
    {
        //for (int i = 0; i < Random.Range(3,10); i++)
        //{
        //    ObstacleSpawn();

        //}

        slowUI[0].GetComponent<SpriteRenderer>().enabled = false;
        slowUI[1].GetComponent<SpriteRenderer>().enabled = false;
        timeValue = 0 ;
        timeValue2 = 0;
        timeValue3 = 0;
        player.GetComponent<PlayerCtl>().startTime = 3;
        player.GetComponent<UnitBase>().movementSpeed = 3;

        if (roomNumber >= 4 && mapType != 0)
        {
            mapSptire.transform.GetChild(0).gameObject.SetActive(false);
            mapSptire.transform.GetChild(1).gameObject.SetActive(true);
            ObstacleGroupSpwan(0);
            range = 0;
            BossSpawn();
        }
        else if (roomNumber >= 5)
        {
            mapSptire.transform.GetChild(0).gameObject.SetActive(false);
            mapSptire.transform.GetChild(1).gameObject.SetActive(true);
            ObstacleGroupSpwan(0);
            range = 0;
            BossSpawn();
        }
        else
        {
            mapSptire.transform.GetChild(0).gameObject.SetActive(true);
            mapSptire.transform.GetChild(1).gameObject.SetActive(false);
            range = Random.Range(1, 17);
            mapType222 = range;
            ObstacleGroupSpwan(range);
            ObstacleSet();
            sp = Vector3.zero;
            for (int i = 0; i < roomNumber; i++)
            {
                MobSpawn();
            }
        }
        
        MapSet();

    }

    void MapSet()
    {
        switch (mapType)
        {
            case 0:
                switch (roomNumber)
                {
                    case 1:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1,0,0);
                        mapPos.transform.localPosition = new Vector3(0.64f, -0.64f, 0);
                        break;
                    case 2:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(0, -0.64f, 0);
                        break;
                    case 3:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1); 
                        mapPos.transform.localPosition = new Vector3(0, 0, 0);
                        break;
                    case 4:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1); 
                        mapPos.transform.localPosition = new Vector3(0, 0.64f, 0);
                        break;
                    case 5:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(0.64f, 0.64f, 0);
                        break;
                }
                break;
            case 1:
                switch (roomNumber)
                {
                    case 1:
                        nextDoor.transform.position = doorPos[3].position;
                        nextDoor.transform.rotation = doorPos[3].rotation;
                        prevDoor.transform.position = doorPos[2].position;
                        prevDoor.transform.rotation = doorPos[2].rotation;
                        player.transform.position = doorPos[2].position + new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(-0.64f, -0.32f, 0);
                        break;
                    case 2:
                        nextDoor.transform.position = doorPos[3].position;
                        nextDoor.transform.rotation = doorPos[3].rotation;
                        prevDoor.transform.position = doorPos[2].position;
                        prevDoor.transform.rotation = doorPos[2].rotation;
                        player.transform.position = doorPos[2].position + new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(0, -0.32f, 0);
                        break;
                    case 3:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[2].position;
                        prevDoor.transform.rotation = doorPos[2].rotation;
                        player.transform.position = doorPos[2].position + new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(0.64f, -0.32f, 0);
                        break;
                    case 4:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1);
                        mapPos.transform.localPosition = new Vector3(0.64f, 0.32f, 0);
                        break;
                }
                break;
            case 2:
                switch (roomNumber)
                {
                    case 1:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(0.64f, -0.32f, 0);
                        break;
                    case 2:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(0, -0.32f, 0);
                        break;
                    case 3:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(-0.64f, -0.32f, 0);
                        break;
                    case 4:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1);
                        mapPos.transform.localPosition = new Vector3(-0.64f, 0.32f, 0);
                        break;
                }
                break;
            case 3:
                switch (roomNumber)
                {
                    case 1:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(0.32f, -0.64f, 0);
                        break;
                    case 2:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(-0.32f, -0.64f, 0);
                        break;
                    case 3:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1);
                        mapPos.transform.localPosition = new Vector3(-0.32f, 0, 0);
                        break;
                    case 4:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1);
                        mapPos.transform.localPosition = new Vector3(-0.32f, 0.64f, 0);
                        break;
                }
                break;
            case 4:
                switch (roomNumber)
                {
                    case 1:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1);
                        mapPos.transform.localPosition = new Vector3(0.32f, -0.64f, 0);
                        break;
                    case 2:
                        nextDoor.transform.position = doorPos[0].position;
                        nextDoor.transform.rotation = doorPos[0].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1);
                        mapPos.transform.localPosition = new Vector3(0.32f, 0, 0);
                        break;
                    case 3:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[1].position;
                        prevDoor.transform.rotation = doorPos[1].rotation;
                        player.transform.position = doorPos[1].position + new Vector3(0, 0, 1);
                        mapPos.transform.localPosition = new Vector3(0.32f, 0.64f, 0);
                        break;
                    case 4:
                        nextDoor.transform.position = doorPos[2].position;
                        nextDoor.transform.rotation = doorPos[2].rotation;
                        prevDoor.transform.position = doorPos[3].position;
                        prevDoor.transform.rotation = doorPos[3].rotation;
                        player.transform.position = doorPos[3].position - new Vector3(1, 0, 0);
                        mapPos.transform.localPosition = new Vector3(-0.32f, 0.64f, 0);
                        break;
                }
                break;
        }
    }
    
    void ObstacleSet()
    {
        ro = -1;
        int f = roomObstacleGroups.transform.GetChild(range).childCount;
        for(int i = 0; i < f; i++)
        {
            ro++;
            roomObstacle[ro] = roomObstacleGroups.transform.GetChild(range).GetChild(i).gameObject;
        }
    }

    void ObstacleSetOff()
    {
        
    }

    void ObstacleGroupSpwan(int num)
    {
        for(int i = 0; i < 17; i++)
        {
            roomObstacleGroups.transform.GetChild(i).gameObject.SetActive(false);
        }
        roomObstacleGroups.transform.GetChild(num).gameObject.SetActive(true);
    }

    //void ObstacleSpawn()
    //{
    //    int i = Random.Range(0, 13);
    //    roomObstacle[ro] = Instantiate(Obstacle[i]);
    //    int x, y;
    //    while (true)
    //    {
    //        x = Random.Range(2, 13);
    //        y = Random.Range(2, 7);
    //        bool set = false;
    //        for(int j = 0; j < ro; j++)
    //        {
    //            if (Vector3.Distance(new Vector3(x, 0, y), roomObstacle[j].transform.position) < 2)
    //            {
    //                set = true;
    //            }
    //        }
    //        if(set == false)
    //        {
    //            break;
    //        }
    //    }
    //    roomObstacle[ro].transform.position = new Vector3(x, 0, y);
    //    ro++;
    //}

    void MobSpawn()
    {
        int i = 0;
        while (true)
        {
            i = Random.Range(0, 3);
            switch (i)
            {
                case 0:
                    if (sp.x == 0)
                    {
                        sp.x = 1;
                        goto gaga;
                    }
                    break;
                case 1:
                    if (sp.y == 0)
                    {
                        sp.y = 1;
                        goto gaga;
                    }
                    break;
                case 2:
                    if (sp.z== 0)
                    {
                        sp.z = 1;
                        goto gag;
                    }else if(sp.x == 1 && sp.y == 1&& sp.z == 1)
                    {
                        goto gag;
                    }
                    break;
            }
        }
    gaga:
        roomMob[ri] = Instantiate(Mob[i]);
        
            int c = 0;
        Debug.Log(c);
        while (c<100)
        {
            Debug.Log(c);
            c++;
           int x = Random.Range(3, 12);
            int y = Random.Range(3, 6);

            bool set = false;
            for (int j = 0; j < ro; j++)
            {
                Debug.Log(Vector3.Distance(new Vector3(x, 0, y), roomObstacle[j].transform.position));
                if (Vector3.Distance(new Vector3(x, 0, y), roomObstacle[j].transform.position) < 2)
                {
                    set = true;
                }
            }
            if (set == false)
            {
                 roomMob[ri].transform.position = new Vector3(x, 0, y);
                break;
            }
        }
        ri++;
        return;
    
    gag:
        roomMob[ri] = Instantiate(Mob[i]);
        roomMob[ri].GetComponent<Revenant>().mapType = mapType222;
        roomMob[ri].transform.position = roomMob[ri].GetComponent<Revenant>().movePoint[mapType222 * 2];
        if(ri == 3)
        {
            roomMob[ri].transform.position += new Vector3(0, 0, -2);
        }



    }

    void BossSpawn()
    {
        int i = Random.Range(0, 2);
        roomMob[ri] = Instantiate(boss[0]);
        int x, y;
        while (true)
        {
            x = Random.Range(2, 13);
            y = Random.Range(2, 7);

            bool set = false;
            for (int j = 0; j < ro; j++)
            {
                if (Vector3.Distance(new Vector3(x, 0, y), roomObstacle[j].transform.position) < 2)
                {
                    set = true;
                }
            }
            if (Vector3.Distance(new Vector3(x, 0, y), player.transform.position) < 2)
            {
                set = true;
            }
            if (set == false)
            {
                break;
            }
        }
        roomMob[ri].transform.position = new Vector3(7, 0, 4);
        ri++;
    }

   public void NextRoom()
    {
        if (roomClear)
        {
            for (int i = 0; i < ro; i++)
            {
                if (roomObstacle[i])
                {
                    if (roomObstacle[i].GetComponent<UnitBase>().teamType == 10)
                    {
                        roomObstacle[i].GetComponent<SpiderWeb>().dead = true;
                    }
                    else if (roomObstacle[i].GetComponent<UnitBase>().teamType == 11)
                    {
                        roomObstacle[i].GetComponent<Trap>().dead = true;
                    }
                    else
                    {
                        Destroy(roomObstacle[i]);
                    }
                }
            }
            ri = 0;
            ro = 0;
            
           


            if (roomNumber >= 4 && mapType != 0)
            {
                
                roomNumber = 1;
                floorNumber++;
                //newMap();
                Camera.main.transform.GetChild(0).gameObject.GetComponent<FadeController>().FadeIn(3, 2);
                //spotLight.GetComponent<FadeController>().FadeIn(3, 1);
                //SceneManager.LoadSceneAsync(2);
                rullet.SetActive(true);
            }
            else if (roomNumber >= 5)
            {
                roomNumber = 1;
                floorNumber++;
                //newMap();
                Camera.main.transform.GetChild(0).gameObject.GetComponent<FadeController>().FadeIn(3, 2);
                //spotLight.GetComponent<FadeController>().FadeIn(3, 1);
                //SceneManager.LoadSceneAsync(2);
                rullet.SetActive(true);
            }
            else
            {
                roomNumber++;
                newRoom();
            }
            
        }
    }

    public void newMap()
    {
        roomNumberText.text = "Floor " + floorNumber;
        int mapValue = Random.Range(0, 100);
        if (mapValue < 27)
        {
            mapType = 1;
            miniMapSptireObject.GetComponent<SpriteRenderer>().sprite = miniMapSptire[1];
        }
        else if (mapValue < 47)
        {
            mapType = 2;
            miniMapSptireObject.GetComponent<SpriteRenderer>().sprite = miniMapSptire[2];
        }
        else if (mapValue < 74)
        {
            mapType = 3;
            miniMapSptireObject.GetComponent<SpriteRenderer>().sprite = miniMapSptire[3];
        }
        else if (mapValue < 94)
        {
            mapType = 4;
            miniMapSptireObject.GetComponent<SpriteRenderer>().sprite = miniMapSptire[4];
        }
        else
        {
            mapType = 0;
            miniMapSptireObject.GetComponent<SpriteRenderer>().sprite = miniMapSptire[0];
        }
    }

    public void Slow1()
    {
        if (player != null)
        {

            if (timeValue <= 0)
            {

                player.GetComponent<UnitBase>().movementSpeed = 3;
                slowUI[0].GetComponent<SpriteRenderer>().enabled = false;
                slowText[0].text = "";

            }
            else
            {
                timeValue -= Time.deltaTime;
                slowText[0].text = Mathf.Round(timeValue) + "s";
            }
        }

    }

    public void Slow2()
    {
        if (player != null)
        {

            if (timeValue3 <= 0)
            {

                slowText[1].text = "";
                slowUI[1].GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                slowText[1].text = Mathf.Round(timeValue3) + "s";
                timeValue3 -= Time.deltaTime;
            }

            if (timeValue2 <= 0 && timeValue3 > 0)
            {
                timeValue2 = 3f;
                player.GetComponent<UnitBase>().HP -= 1;
                player.GetComponent<PlayerCtl>().Hit();
            }
            else
            {
                timeValue2 -= Time.deltaTime;
                
            }
        }
    }

    void TimeCheck()
    {
        timeValue4 += Time.deltaTime;
        timeCheck.text = Mathf.Round(timeValue4)+"s";
    }
}
