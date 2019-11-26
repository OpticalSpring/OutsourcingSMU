using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAlpha : MonoBehaviour
{
    public float allTime;
    SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void InAlphaChange()
    {
        StartCoroutine("In");
    }

   IEnumerator In()
    {
        for(int i = 0; i< 100; i++)
        {
            spr.color = new Vector4(1, 1, 1, (float)i/100);
            yield return new WaitForSeconds(allTime / 100);
        }
    }

    public void OutAlphaChange()
    {
        StartCoroutine("Out");
    }

    IEnumerator Out()
    {
        for (int i = 0; i < 100; i++)
        {
            spr.color = new Vector4(1, 1, 1, (100- (float)i)/100);
            yield return new WaitForSeconds(allTime / 100);
        }
    }
}
