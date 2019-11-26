using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Berserker : MonoBehaviour
{
    public Image berserkerImage;
    public float berserkerPoint;
    bool berserkerOn;
    float berserkerTime;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PointChange");
    }

    // Update is called once per frame
    void Update()
    {
        if(berserkerOn == true)
        {
           if(berserkerTime > 5)
            {
                berserkerOn = false;
                GameObject.Find("Player").GetComponent<PlayerCtl>().berserkerOn = false;
            }
            else
            {
                berserkerTime += Time.deltaTime;
            }
        }
    }

    IEnumerator PointChange()
    {
        while (true)
        {
            berserkerPoint += 0.5f;

            if(berserkerPoint > 100)
            {
                berserkerPoint = 100;
                if(berserkerOn == false)
                {
                    berserkerOn = true;
                    berserkerTime = 0;
                    GameObject.Find("Player").GetComponent<PlayerCtl>().berserkerOn = true;
                }
            }
            berserkerImage.fillAmount = berserkerPoint * 0.01f;
            yield return new WaitForSeconds(1f);
            if (berserkerOn == true)
            {
                berserkerPoint -= 21;
            }
        }
    }

    public void PointUp(int point)
    {
        berserkerPoint += point;
        berserkerImage.fillAmount = berserkerPoint * 0.01f;
    }
}
