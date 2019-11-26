using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    SoundManager soundManager;
    public Slider vol;
    public Toggle tog;
    float oldV;
    public float tim;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        oldV = vol.value;
        //vol.value = Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().vol;
        //if (Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().tog == 1)
        //{
        //    tog.isOn = true;
        //}
        //else
        //{
        //    tog.isOn = false;
        //}
    }
    

    
    
        
    

    // Update is called once per frame
    void Update()
    {
        if (oldV != vol.value)
        {
            oldV = vol.value;
            soundManager.VolumeChange(vol.value);
        }
        if(tog.isOn == true)
        {
            soundManager.VolumeChange(0);
        }
        else
        {
            soundManager.VolumeChange(vol.value);
        }

        //if(tim < 0)
        //{
        //    AutoSave();
        //    tim = 1;
        //}
        //else
        //{
        //    tim -= Time.fixedDeltaTime;
        //}
    }

    void AutoSave()
    {
            Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().vol = vol.value;
            if (tog.isOn == true) {
                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().tog = 1;
            }
            else
            {
                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().tog = 0;
            }
        Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataSave();
    }
}
