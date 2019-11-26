using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    float distance = 10;
    public bool right;
    public GameObject otherHand;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        newPosition.y = transform.position.y;
        
        if (right)
        {
            if(newPosition.x > transform.position.x)
            {
                transform.position = newPosition;
                newPosition.x *= -1;
                otherHand.transform.position = newPosition;
            }
        }
        else
        {
            if (newPosition.x < transform.position.x)
            {
                transform.position = newPosition;
                newPosition.x *= -1;
                otherHand.transform.position = newPosition;
            }
        }
    }
    
}
