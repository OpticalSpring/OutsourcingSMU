using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBackgorundMove : MonoBehaviour
{
    public float dist;
    private Vector3 MouseStart;
    private Vector3 derp;
    public bool OnDrag;
    public Vector2 outSide;

    private void Update()
    {
        if(Time.timeScale == 1)
        if (OnDrag == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
                MouseStart.y = transform.position.y;

            }
            else if (Input.GetMouseButton(0))
            {
                var MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
                MouseMove.y = transform.position.y;
                transform.position = transform.position + (MouseMove - MouseStart);
            }
        }

        if (gameObject.transform.position.x < outSide.x)
        {
            Vector3 newPos = gameObject.transform.position;
            newPos.x = outSide.x;
            gameObject.transform.position = newPos;
        }
        if (gameObject.transform.position.x > outSide.y)
        {
            Vector3 newPos = gameObject.transform.position;
            newPos.x = outSide.y;
            gameObject.transform.position = newPos;
        }
    }
}
