using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject[] Sound;
    private void Awake()
    {
        for (int i = 0; i < Sound.Length; i++)
        {
            Sound[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    public void VolumeChange(float v)
    {
        for (int i = 0; i < Sound.Length; i++)
        {
            Sound[i].GetComponent<AudioSource>().volume = v;
        }
    }

    public void SoundPlay(int i)
    {
        Sound[i].GetComponent<AudioSource>().Play();
    }
    public void SoundStop(int i)
    {
        StartCoroutine(I1(i));
    }

    public void NewSound(int i)
    {
        GameObject sound = Instantiate(Sound[i]);
        sound.GetComponent<AudioSource>().Play();
        Destroy(sound, 1);
    }

    IEnumerator I1(int i)
    {
        for (int j = 100; j > 0; j--)
        {
            Sound[i].GetComponent<AudioSource>().volume = (float)j / 100;
            yield return new WaitForSeconds(0.01f);
        }
    }
}