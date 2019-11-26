using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWalk : MonoBehaviour
{
    public GameObject[] cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPos[0].transform.position, 10 * Time.deltaTime);
        Turn(gameObject, cameraPos[1].transform.position);
    }


    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(30, rotateDegree, 0), 500 * Time.deltaTime);
    }
}
