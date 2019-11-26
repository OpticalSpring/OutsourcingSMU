using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCtrl : MonoBehaviour
{
    float distance = 10;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        newPosition.z = -0.1f;
        gameObject.transform.position = newPosition;
        Camera.main.GetComponent<BackgroundMove>().OnDrag = true;
    }

    private void OnMouseUp()
    {
        Camera.main.GetComponent<BackgroundMove>().OnDrag =false;
    }
    
}
