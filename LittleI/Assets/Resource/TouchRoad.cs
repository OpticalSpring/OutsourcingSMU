using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchRoad : MonoBehaviour
{
    Vector3 oldPos;
    public int a;
    public Image imagedd;
    public Sprite[] spr;
    public bool sp;
    // Start is called before the first frame update
    void Start()
    {
         oldPos= gameObject.transform.GetChild(0).position;
        StartCoroutine("turn");
        if(sp == true)
        {
            Destroy(gameObject, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sp == false)
        {
            if (Vector3.Distance(gameObject.transform.GetChild(0).position, gameObject.transform.GetChild(1).position) < 10)
            {
                gameObject.transform.GetChild(0).position = oldPos;
                a++;
                if (a >= 2)
                {
                    Destroy(gameObject);
                }
            }
            gameObject.transform.GetChild(0).position = Vector3.Slerp(gameObject.transform.GetChild(0).position, gameObject.transform.GetChild(1).position, Time.deltaTime);
        }
    }

    IEnumerator turn()
    {
        while (true)
        {
            imagedd.sprite = spr[0];
            yield return new WaitForSeconds(0.5f);
            imagedd.sprite = spr[1];
            yield return new WaitForSeconds(0.5f);
        }
    }
}
