using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public float angle;
    public float length;
    public Vector3 newPos;
    public Vector3 nextPos;
    bool a;
    float gg;
    public bool die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (die == false) 
        NoDie();


    }

    void NoDie()
    {

        if (length < gg)
        {
            nextPos = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
            length = 30;
            gg = Random.Range(0, 50);
            if (a == true) a = false; else a = true;
        }
        if (a == true)
        {
            angle += Time.deltaTime * 0.5f;

        }
        else
        {
            angle += Time.deltaTime * -0.5f;

        }
        length -= Time.deltaTime * 5f;
        newPos.x = nextPos.x + length * Mathf.Cos(angle);
        newPos.y = nextPos.x + length * Mathf.Sin(angle);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPos, Time.deltaTime * 0.5f);

        if (gameObject.transform.position.x > newPos.x)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Rotation", 0);
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Rotation", 1);
            //    gameObject.transform.GetChild(1).gameObject.SetActive(true);
            //    gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(38);
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
        die = true;
        if (gameObject.transform.position.x > newPos.x)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        StartCoroutine("gogi");
    }

    IEnumerator gogi()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.GetChild(5).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
