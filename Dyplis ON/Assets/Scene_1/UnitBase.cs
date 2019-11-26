using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public int teamType;
    public float HP;
    public float HP_MAX;
    public float movementSpeed;
    public int unitType;
    // Start is called before the first frame update
    void Start()
    {
        HP_MAX = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            switch (unitType)
            {
                case 1:
                    GetComponent<PlayerCtl>().Dead();
                    break;
                case 2:
                    GetComponent<Eater>().Dead();
                    break;
                case 3:
                    GetComponent<Bomber>().Dead();
                    break;
                case 4:
                    GetComponent<Boop>().Dead();
                    break;
                case 5:
                    GetComponent<Revenant>().Dead();
                    break;
            }
        }
        if(unitType != 0)
            Back();
    }

    void Back()
    {
        if(gameObject.transform.position.x <0 || gameObject.transform.position.x > 14 || gameObject.transform.position.z < 0 || gameObject.transform.position.z > 8)
        {
            gameObject.transform.position = new Vector3(7, 0, 4);
        }
    }

    public void Hit(float damage)
    {
        HP -= damage;
        switch (unitType)
        {
            case 1:
                if (GetComponent<PlayerCtl>().berserkerOn == true) {
                    HP += damage;
                }
                else
                {

                    GetComponent<PlayerCtl>().Hit();
                }
                break;
            case 2:
                GetComponent<Eater>().Hit();
                break;
            case 3:
                GetComponent<Bomber>().Hit();
                break;
            case 4:
                GetComponent<Boop>().Hit();
                break;
            case 5:
                GetComponent<Revenant>().Hit();
                break;

        }
    }
}
