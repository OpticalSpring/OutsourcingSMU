using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager_8 : MonoBehaviour
{
    public GameObject[] hand;
    public Vector3[] handRotate;
    public GameObject foxTail;
    public Vector3 foxVector;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RotateNe");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(10); GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(42);
    }

    // Update is called once per frame
    void Update()
    {
        hand[0].transform.eulerAngles = Vector3.Lerp(hand[0].transform.eulerAngles, handRotate[0], 5*Time.deltaTime);
        hand[1].transform.eulerAngles = Vector3.Lerp(hand[1].transform.eulerAngles, handRotate[1], 5 * Time.deltaTime);
        foxTail.transform.eulerAngles = Vector3.Lerp(foxTail.transform.eulerAngles, foxVector, 5 * Time.deltaTime);
    }

    public void GameClear()
    {
        PlayerPrefs.SetInt("VideoNumber", 9);
        GameObject.Find("InteractionNextScene").transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator RotateNe()
    {
        while (true)
        {
            handRotate[0] = new Vector3(0, 0, 1);
            handRotate[1] = new Vector3(0, 0, 361);
           foxVector = new Vector3(0, 0,330);
            yield return new WaitForSeconds(0.2f);

            handRotate[0] = new Vector3(0, 0, 30);
            handRotate[1] = new Vector3(0, 0, 330);
            foxVector = new Vector3(0, 0, 360);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
