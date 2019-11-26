using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager_6 : MonoBehaviour
{
    public int gok;

    public GameObject[] Hola;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(8);
    }

    // Update is called once per frame
    void Update()
    {
        if(gok == 1)
        {
            gok++;
            Hola[0].GetComponent<SpriteAlpha>().OutAlphaChange();
            Hola[1].GetComponent<SpriteAlpha>().InAlphaChange();
            Hola[2].GetComponent<SpriteAlpha>().OutAlphaChange();
            Hola[3].GetComponent<SpriteAlpha>().InAlphaChange();
            StartCoroutine("OO");
        }
    }
    IEnumerator OO()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(40);
        Hola[4].GetComponent<SpriteAlpha>().InAlphaChange();
        yield return new WaitForSeconds(1f);
        Hola[4].GetComponent<SpriteAlpha>().OutAlphaChange();
        yield return new WaitForSeconds(1f);
        Hola[4].GetComponent<SpriteAlpha>().InAlphaChange();
        yield return new WaitForSeconds(1f);
        Hola[4].GetComponent<SpriteAlpha>().OutAlphaChange();
        yield return new WaitForSeconds(1f);
        Hola[4].GetComponent<SpriteAlpha>().InAlphaChange();
        yield return new WaitForSeconds(1f);
        Hola[4].GetComponent<SpriteAlpha>().OutAlphaChange();
        yield return new WaitForSeconds(5f);
        Clear();
    }

    void Clear()
    {
        PlayerPrefs.SetInt("VideoNumber", 6);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
