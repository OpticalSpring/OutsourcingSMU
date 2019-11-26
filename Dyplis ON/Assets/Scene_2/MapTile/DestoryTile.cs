using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Destroy(gameObject, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 1f);
        }


    }

   
}
