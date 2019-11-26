using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDrag : MonoBehaviour
{
    public bool interaction;
    float distance = 10;
    void OnMouseDrag()
    {
        if (interaction == true)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            gameObject.transform.position = newPosition;
        }
    }
    
}
