using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager_5 : MonoBehaviour
{
    public GameObject backImage;
    public GameObject iceImage;
    public GameObject foxImage;
    public Vector3 newPos;
    public int count;
    public Sprite[] spr;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7);
    }

    // Update is called once per frame
    void Update()
    {
        backImage.transform.localPosition = Vector3.MoveTowards(backImage.transform.localPosition, newPos, Time.deltaTime * 200);
        iceImage.GetComponent<Image>().fillAmount += Time.deltaTime * 0.2f;
    }
    public void Touch()
    {
        #if UNITY_ANDROID
        Handheld.Vibrate();
        #endif

        count++;

        if (count == 5) { iceImage.GetComponent<Image>().sprite = spr[0]; GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(39); }
        if (count == 10) { iceImage.GetComponent<Image>().sprite = spr[1]; GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(39); }
        if (count == 15) { iceImage.GetComponent<Image>().sprite = spr[2]; GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(39); }
        if (count == 20)
        {
            iceImage.GetComponent<Image>().sprite = spr[3];
            StartCoroutine("NextScene"); GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(39);
        }
    }

    IEnumerator NextScene()
    {
        foxImage.GetComponent<Rigidbody2D>().gravityScale = 20;
        yield return new WaitForSeconds(3f);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }
}
