using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RunManager : MonoBehaviour
{
    public GameObject player;
    public GameObject I_TILE, T_TILE,L_TILE;
    public GameObject[] i_TlLE;

    public Vector3 newPos;
    public int i_count;
    public int t_count;
    public int rotation;
    public bool rotationSet = true;
    Vector3 aCheck, bCheck;
    int defaultRotation;

    public GameObject[] tTileObject;

    public GameObject optionObject;
    public bool optionSet;
    // Start is called before the first frame update
    void Start()
    {
        newPos = Vector3.zero;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1);
    }
    public void OptionOpen()
    {
        if (optionSet)
        {
            optionObject.SetActive(false);
            optionSet = false;
            Time.timeScale = 1;
        }
        else
        {
            optionObject.SetActive(true);
            optionSet = true;
            Time.timeScale = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionSet)
            {
                optionObject.SetActive(false);
                optionSet = false;
                Time.timeScale = 1;
            }
            else
            {
                optionObject.SetActive(true);
                optionSet = true;
                Time.timeScale = 0;
            }
        }


        if (Vector3.Distance(player.transform.position, newPos) < 100)
        {
            if (rotationSet)
            {
                if (i_count < 1)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        i_count++;
                        RotationPos();
                        Spawn_I_TILE(newPos, i);
                    }
                }
                else if (t_count > 2)
                {

                    i_count = 0;
                    t_count = 0;
                    RotationPos();
                    T_TileSet();
                    rotationSet = false;
                }
                else
                {
                    t_count++;
                    i_count = 0;
                    RotationPos();
                    RotationChange();
                    Spawn_L_TILE(newPos);
                }
            }
            else
            {
                if(Vector3.Distance(player.transform.position, aCheck) < 80)
                {
                    rotationSet = true;
                    newPos = aCheck;
                    rotation--;
                    if (rotation < 0)
                    {
                        rotation = 3;
                    }
                    RotationPos();
                    RotationChange();
                    Spawn_L_TILE(newPos);

                    for (int i = 0; i < 9; i++)
                    {
                        Destroy(tTileObject[2 * i+1]);
                    }
                }
                else if(Vector3.Distance(player.transform.position, bCheck) < 80)
                {
                    rotationSet = true;
                    newPos = bCheck;
                    rotation++;
                    if (rotation >3)
                    {
                        rotation = 0;
                    }
                    RotationPos();
                    RotationChange();
                    Spawn_L_TILE(newPos);

                    for (int i = 0; i < 9; i++)
                    {
                        Destroy(tTileObject[2 * i]);
                    }
                }
            }
        }
    }

    void T_TileSet()
    {
        Spawn_T_TILE(newPos);
        Vector3 aPos, bPos;
        aPos = newPos;
        bPos = newPos;
        int rot = rotation;
        for (int i = 0; i < 9; i++)
        {
            switch (rotation)
            {
                case 0:
                    aPos.x -= 10;
                    bPos.x += 10;
                    break;
                case 1:
                    aPos.z += 10;
                    bPos.z -= 10;
                    break;
                case 2:
                    aPos.x += 10;
                    bPos.x -= 10;
                    break;
                case 3:
                    aPos.z -= 10;
                    bPos.z += 10;
                    break;
            }


                rotation -= 1;
            

            if (rotation < 0)
            {
                rotation = 3;
            }
            else if (rotation > 3)
            {
                rotation = 0;
            }
            Spawn_I_TILE_T(aPos, 2*i);

            rotation = rot;
            rotation += 1;

            if (rotation < 0)
            {
                rotation = 3;
            }
            else if (rotation > 3)
            {
                rotation = 0;
            }
            Spawn_I_TILE_T(bPos , 2*i+1);

            rotation = rot;
        }
        aCheck = aPos;
        bCheck = bPos;
    }

    void RotationPos()
    {
        switch (rotation)
        {
            case 0:
                newPos.z += 10;
                break;
            case 1:
                newPos.x += 10;
                break;
            case 2:
                newPos.z -= 10;
                break;
            case 3:
                newPos.x -= 10;
                break;
        }
    }

    void RotationChange()
    {
        if (Random.Range(0, 1.0f) < 0.5f)
        {
            rotation += 1;
            defaultRotation = 2;
        }
        else
        {
            rotation -= 1;
            defaultRotation = 1;
        }

        if (rotation < 0)
        {
            rotation = 3;
        }
        else if (rotation > 3)
        {
            rotation = 0;
        }




        
        
    }
    void Spawn_I_TILE_T(Vector3 pos, int i)
    {
        GameObject temp = Instantiate(I_TILE);
        tTileObject[i] = temp;
        temp.transform.position = pos;
        switch (rotation)
        {
            case 0:
                temp.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 1:
                temp.transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 2:
                temp.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 3:
                temp.transform.eulerAngles = new Vector3(0, 270, 0);
                break;
        }
    }

    void Spawn_I_TILE(Vector3 pos, int i)
    {
        GameObject temp = Instantiate(i_TlLE[i]);
        temp.transform.position = pos;
        switch (rotation)
        {
            case 0:
                temp.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 1:
                temp.transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 2:
                temp.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 3:
                temp.transform.eulerAngles = new Vector3(0, 270, 0);
                break;
        }
    }

    void Spawn_T_TILE(Vector3 pos)
    {
        GameObject temp = Instantiate(T_TILE);
        temp.transform.position = pos;
        switch (rotation)
        {
            case 0:
                temp.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 1:
                temp.transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 2:
                temp.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 3:
                temp.transform.eulerAngles = new Vector3(0, 270, 0);
                break;
        }
    }

    void Spawn_L_TILE(Vector3 pos)
    {
        GameObject temp = Instantiate(L_TILE);
        temp.transform.position = pos;

        switch (rotation)
        {
            case 0:
                if (defaultRotation == 1)
                {
                    temp.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                else if(defaultRotation == 2)
                {
                    temp.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                break;
            case 1:
                if (defaultRotation == 1)
                {
                    temp.transform.eulerAngles = new Vector3(0, 00, 0);
                }
                else if (defaultRotation == 2)
                {
                    temp.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                break;
            case 2:
                if (defaultRotation == 1)
                {
                    temp.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (defaultRotation == 2)
                {
                    temp.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                break;
            case 3:
                if (defaultRotation == 1)
                {
                    temp.transform.eulerAngles = new Vector3(0,180, 0);
                }
                else if (defaultRotation == 2)
                {
                    temp.transform.eulerAngles = new Vector3(0, 270, 0);
                }
                break;
        }
    }
    

    public void OptionClose()
    {
        optionObject.SetActive(false);
        optionSet = false;
        Time.timeScale = 1;
    }

    public void Title()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
