using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    public GameObject runner;
    RunPlayer runPlayer;

    private void Start()
    {
        runPlayer = runner.GetComponent<RunPlayer>();
    }

    private void Update()
    {
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            runPlayer.coinCount++;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            runPlayer.HP-=10;
            runPlayer.charAnimator.SetBool("Hit", true);
        }
        if (other.gameObject.CompareTag("Obstacle2"))
        {
            if (runPlayer.charAnimator.GetBool("Slide") == false)
            {
                runPlayer.HP -= 10;
                runPlayer.charAnimator.SetBool("Hit", true);
                Debug.Log("dd");
            }
            else
            {
                Debug.Log("SAF");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            runPlayer.charAnimator.SetBool("Hit", false);
        }
        if (other.gameObject.CompareTag("Obstacle2"))
        {
            runPlayer.charAnimator.SetBool("Hit", false);
        }
    }
}
