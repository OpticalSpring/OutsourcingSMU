using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxCtrl : MonoBehaviour
{
    public GameObject maskObject;
    float distance = 10;
    public Vector3 spawnPosition;
    bool left;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(spawnPosition, gameObject.transform.position) > 2)
        {
            spawnPosition = gameObject.transform.position;
            GameObject mask = Instantiate(maskObject, spawnPosition, gameObject.transform.rotation);
            GameObject.Find("MiniGameManager").GetComponent<MiniGameManager_2>().percent += 5;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(27);
            if (left)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Left", true);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Left", false);
            }

        }
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (gameObject.transform.position.x > newPosition.x)
        {
            left = true;
        }
        else
        {
            left = false;
        }
        gameObject.transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.gameObject.name);
        if(other.GetComponent<ObjectID>().ID == 2)
        {
           //other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
    }

    
}
