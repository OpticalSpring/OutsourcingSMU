using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public void Touch()
    {
        GameObject.Find("MiniGameManager").GetComponent<MiniGameManager_2>().Clear();
    }
}
