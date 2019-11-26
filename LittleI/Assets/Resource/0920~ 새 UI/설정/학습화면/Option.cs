using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public bool on;
    public bool mute;
    public Slider sli;
    public Image mImage;
    public Sprite[] mSpr;
    public GameObject touchEffect;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void op()
    {
        if (on == true)
        {
            on = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            on = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (on == true) 
            {
                on = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                on = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(touchEffect);
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            temp.transform.position = newPos;
            Destroy(temp, 2);

        }
    }

   public void SoundChange()
    {
        if (mute == false)
        {
            soundManager.Sound[0].GetComponent<AudioSource>().volume = sli.value;
            soundManager.Sound[1].GetComponent<AudioSource>().volume = sli.value;
        }
    }

    public void GoMain() { 
         Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    public void Mute()
    {
        if(mute == true)
        {
            mute = false;
            mImage.sprite = mSpr[0];
            soundManager.Sound[0].GetComponent<AudioSource>().volume = sli.value;
            soundManager.Sound[1].GetComponent<AudioSource>().volume = sli.value;
        }
        else
        {
            mute = true;
            mImage.sprite = mSpr[1];
            soundManager.Sound[0].GetComponent<AudioSource>().volume = 0;
            soundManager.Sound[1].GetComponent<AudioSource>().volume = 0;
        }
    }
}
