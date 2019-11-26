using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    UnitBase unitBase;
    public float damagePoint;
    Animator animator;
    bool bom; public GameObject warningObj;
    // Start is called before the first frame update
    void Start()
    {
        unitBase = GetComponent<UnitBase>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bom == false)
        {
            
            bomb();
        }
    }

    void bomb()
    {
        Collider[] cols = Physics.OverlapBox(gameObject.transform.position, new Vector3(1,1,1));

        foreach (Collider col in cols)
            if (unitBase.teamType != col.gameObject.GetComponent<UnitBase>().teamType && col.gameObject.GetComponent<UnitBase>().teamType != 0 && col.gameObject.GetComponent<UnitBase>().unitType != 0)
            {
                warningObj.SetActive(true);
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(3);
                bom = true;
                col.gameObject.GetComponent<UnitBase>().Hit(damagePoint);
                animator.SetBool("Attack", true);
                Destroy(gameObject,1);
            }
    }

    public void Hit()
    {

    }

    public void Dead()
    {
        animator.SetBool("Dead", true);
        Destroy(gameObject, 1);
    }
}
