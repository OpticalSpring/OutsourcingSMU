using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inbu : MonoBehaviour
{
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = new Vector3(Random.Range(-5, 5), 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, nextPos, 10 * Time.deltaTime);
    }
}
