using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPopup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;    
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.one, Time.fixedDeltaTime * 3);
    }
}
