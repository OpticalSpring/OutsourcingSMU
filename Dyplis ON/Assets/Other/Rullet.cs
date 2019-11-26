using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rullet : MonoBehaviour
{
    
    public bool on;
    public float power;
    public GameObject spotLight;

    // Start is called before the first frame update
    void Start()
    {
        power = Random.Range(10000, 50000);
        if (Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().ticket > 0)
        {
            Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().ticket -= 1;
            Time.timeScale = 0;
            on = true;
        }
        else
        {
            NextScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on == true)
        {
            gameObject.transform.Rotate(Vector3.forward * Time.fixedDeltaTime * power);
            if(power < 1)
            {
                Debug.Log(gameObject.transform.eulerAngles.z);
                on = false;
                if(gameObject.transform.eulerAngles.z < 45)
                {
                    Debug.Log("꽝");
                    Award(0);
                }
                else if (gameObject.transform.eulerAngles.z < 90)
                {
                    Debug.Log("룰렛");
                    Award(3);
                }
                else if (gameObject.transform.eulerAngles.z < 135)
                {
                    Debug.Log("천리안");
                    Award(1);
                }
                else if (gameObject.transform.eulerAngles.z < 180)
                {
                    Debug.Log("꽝");
                    Award(0);
                }
                else if (gameObject.transform.eulerAngles.z < 225)
                {
                    Debug.Log("체력업");
                    Award(2);
                }
                else if (gameObject.transform.eulerAngles.z < 270)
                {
                    Debug.Log("룰렛티켓");
                    Award(3);
                }
                else if (gameObject.transform.eulerAngles.z < 315)
                {
                    Debug.Log("천리안");
                    Award(1);
                }
                else if (gameObject.transform.eulerAngles.z < 360)
                {
                    Debug.Log("체력업");
                    Award(2);
                }

            }
            else
            {
                power = Mathf.Lerp(power, 0, Time.fixedDeltaTime);
            }
        }
    }

    void Award(int num)
    {
        switch (num)
        {
            case 0:

                break;
            case 1:
                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_1 = 1;
                break;
            case 2:
                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataItem_2 = 1;
                break;
            case 3:
                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().ticket += 1;
                break;
        }
        Time.timeScale = 1;
        NextScene();
    }

    void NextScene()
    {
        spotLight.GetComponent<FadeController>().FadeIn(3, 1);
    }
    
}
