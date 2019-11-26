using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
   public int nowScene;
    
    public VideoPlayer[] video;
    public int[] videoTIme;
    public int[] nextSceneNumber;
    public bool pause;
    public Image button;
    public Sprite[] bSpr;
    public Slider sli;
    public bool s;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            video[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<VideoPlayer>();
        }

        nowScene = PlayerPrefs.GetInt("VideoNumber");
        VideoPlay();
        StartCoroutine("tt");
    }

    // Update is called once per frame
    void Update()
    {
        if( s == false&&video[nowScene].time >= video[nowScene].length-0.5f )
        {
            s = true;
            SceneManager.LoadSceneAsync(nextSceneNumber[nowScene]);
        }
    }
    public void VedioTimeSet()
    {
        if(Input.GetMouseButton(0))
        video[nowScene].time = sli.value * video[nowScene].length;
    }
    IEnumerator tt()
    {
        while (true)
        {
            sli.value = (float)(video[nowScene].time / video[nowScene].length);
            yield return new WaitForSeconds(1f);
        }
    }

    void VideoPlay()
    {
        video[nowScene].Play();
    }
    

    IEnumerator NextTimeSet()
    {
        yield return new WaitForSeconds((float)video[nowScene].clip.length);
        SceneManager.LoadSceneAsync(nextSceneNumber[nowScene]);
    }

    public void VideoPause()
    {
        if(pause == true)
        {
            pause = false;
            video[nowScene].Play();
            button.sprite = bSpr[0];
        }
        else
        {
            pause = true;
            video[nowScene].Pause();
            button.sprite = bSpr[1];
        }
    }
}
