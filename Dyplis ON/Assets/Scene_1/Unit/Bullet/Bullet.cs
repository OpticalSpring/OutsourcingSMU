using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int teamType;
    public float moveSpeed;
    public float damagePoint;
    public Vector3 startPos;
    public float limitValue;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if(Vector3.Distance(startPos, gameObject.transform.position) > limitValue)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        UnitBase target = other.gameObject.GetComponent<UnitBase>();
        if (target.teamType == 0)
        {
           Destroy(gameObject);
        }
        else if (teamType != target.teamType && target.teamType != 10&& target.teamType != 11)
        {
            

            target.Hit(damagePoint);
            Destroy(gameObject);
           
        }
    }
}
