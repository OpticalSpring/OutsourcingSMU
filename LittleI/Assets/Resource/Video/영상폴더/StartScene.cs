using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartScene : MonoBehaviour
{
    public VideoPlayer[] video;
    public int eventNumber;
    // Start is called before the first frame update
    void Start()
    {
        video[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(video[eventNumber].time >= video[eventNumber].length - 0.5f)
        {
            eventNumber++;
            if (eventNumber == 4)
            {
                SceneManager.LoadSceneAsync(0);
            }else
            video[eventNumber].Play();
        }
            if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
