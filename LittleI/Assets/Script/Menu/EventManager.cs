using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public int nowSceneNumber, nextSceneNumber, videoNumber, preSceneNumber;
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void NextScene()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("VideoNumber", videoNumber);
        SceneManager.LoadSceneAsync(nextSceneNumber);
    }

    public void PreScene()
    {
        SceneManager.LoadSceneAsync(preSceneNumber);
    }

    public void RePlay()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(nowSceneNumber);
    }
}
