using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTile : MonoBehaviour
{
    GameObject other;
    private void Update()
    {
        if (other != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 pos = gameObject.transform.position;
                pos.y = other.transform.position.y;
                other.transform.position = pos;
                other.transform.Rotate(Vector3.up * -90);
                other = null;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 pos = gameObject.transform.position;
                pos.y = other.transform.position.y;
                other.transform.position = pos;
                other.transform.Rotate(Vector3.up * 90);
                other = null;
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            other = col.gameObject;
            col.gameObject.GetComponent<RunPlayer>().tileRotate = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {

            col.gameObject.GetComponent<RunPlayer>().tileRotate = false;
            other = null;
        }
    }
}
