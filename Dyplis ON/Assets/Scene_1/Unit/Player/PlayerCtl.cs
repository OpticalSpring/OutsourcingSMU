using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : MonoBehaviour
{
    UnitBase unitBase;
    public GameObject spriteObject;
    Animator animator;
    public GameObject firePos;
    public GameObject Bullet;
    public float normalDamagePoint;
    float timeV = 0;
    float timeV2 = 0;
    int rotV = 1;
    public GameObject UI_Object;

    public GameObject areaFireObject;
    public GameObject[] areaFirePos;
    bool Set;
    public GameObject spotLight;
    public bool berserkerOn;
    int b;
    public float startTime;

   float a;
    // Start is called before the first frame update
    void Start()
    {
        unitBase = GetComponent<UnitBase>();
        animator = spriteObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unitBase.HP > 0)
        {
            animator.SetBool("Move", false);
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Translate(Vector3.forward * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                gameObject.transform.Translate(Vector3.left * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                animator.SetInteger("Rotation", 2);
                animator.SetBool("Move", true);
                rotV = 2;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Translate(Vector3.back * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                gameObject.transform.Translate(Vector3.right * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                animator.SetInteger("Rotation", 3);
                animator.SetBool("Move", true);
                rotV = 3;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.Translate(Vector3.left * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                gameObject.transform.Translate(Vector3.back * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                animator.SetInteger("Rotation", 2);
                animator.SetBool("Move", true);
                rotV = 2;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.Translate(Vector3.right * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                gameObject.transform.Translate(Vector3.forward * unitBase.movementSpeed / 1.4f * Time.deltaTime * b);
                animator.SetInteger("Rotation", 3);
                animator.SetBool("Move", true);
                rotV = 3;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.Translate(Vector3.forward * unitBase.movementSpeed * Time.deltaTime * b);
                animator.SetInteger("Rotation", 0);
                animator.SetBool("Move", true);
                rotV = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.Translate(Vector3.back * unitBase.movementSpeed * Time.deltaTime * b);
                animator.SetInteger("Rotation", 1);
                animator.SetBool("Move", true);
                rotV = 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Translate(Vector3.left * unitBase.movementSpeed * Time.deltaTime * b);
                animator.SetInteger("Rotation", 2);
                animator.SetBool("Move", true);
                rotV = 2;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Translate(Vector3.right * unitBase.movementSpeed * Time.deltaTime * b);
                animator.SetInteger("Rotation", 3);
                animator.SetBool("Move", true);
                rotV = 3;
            }

            //if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
            //    animator.SetInteger("Rotation", 0);
            //    firePos.transform.eulerAngles = new Vector3(0, 0, 0);
            //    rotV = 0;
            //    Shot();
            //}
            //else if (Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //    animator.SetInteger("Rotation", 1);
            //    firePos.transform.eulerAngles = new Vector3(0, 180, 0);
            //    rotV = 1;
            //    Shot();
            //}
            //else if (Input.GetKeyDown(KeyCode.LeftArrow))
            //{
            //    animator.SetInteger("Rotation", 2);
            //    firePos.transform.eulerAngles = new Vector3(0, 270, 0);
            //    rotV = 2;
            //    Shot();
            //}
            //else if (Input.GetKeyDown(KeyCode.RightArrow))
            //{
            //    animator.SetInteger("Rotation", 3);
            //    firePos.transform.eulerAngles = new Vector3(0, 90, 0);
            //    rotV = 3;
            //    Shot();
            //}
            //else if (Input.GetKeyDown(KeyCode.E))
            //{
            //    AreaShot();
            //}
            if(startTime > 0)
            {
                startTime -= Time.deltaTime;
            }
            
            if (timeV <= 0)
            {
                animator.SetBool("Shot", false);
                Search();
            }
            else
            {
                switch (rotV)
                {
                    case 0:
                        animator.SetInteger("Rotation", 0);
                        break;
                    case 1:
                        animator.SetInteger("Rotation", 1);
                        break;
                    case 2:
                        animator.SetInteger("Rotation", 2);
                        break;
                    case 3:
                        animator.SetInteger("Rotation", 3);
                        break;
                }
                timeV -= Time.deltaTime;
            }

            if (timeV2 <= 0)
            {
                animator.SetBool("Hit", false);
            }
            else
            {
                timeV2 -= Time.deltaTime;
            }
        }
        else
        {
            if (Set == false)
            {
                Set = true;
                Camera.main.transform.GetChild(0).gameObject.GetComponent<FadeController>().FadeIn(3, 1);
                spotLight.GetComponent<FadeController>().FadeIn(3, 1);
            }
        }

        if(berserkerOn == true)
        {
            animator.SetBool("Ing", true);
            animator.SetFloat("IngRotation", rotV);
            unitBase.HP = a;
            b = 2;
        }
        else
        {
            a = unitBase.HP;
            animator.SetBool("Ing", false);
            b = 1;
        }
    }

    void Shot()
    {
        if (startTime < 0)
        {
            timeV = 0.3f;
            animator.SetBool("Shot", true);
            GameObject temp = Instantiate(Bullet);
            temp.transform.position = firePos.transform.position;
            temp.transform.rotation = firePos.transform.rotation;
            temp.GetComponent<Bullet>().moveSpeed = 10;
            temp.GetComponent<Bullet>().damagePoint = normalDamagePoint;
            temp.GetComponent<Bullet>().teamType = unitBase.teamType;
            temp.GetComponent<Bullet>().limitValue = 15;
        }
        else
        {
           
        }
    }

    void AreaShot()
    {
        timeV = 0.3f;
        animator.SetBool("Shot", true);
        switch (rotV)
        {
            case 0:
                areaFireObject.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 1:
                areaFireObject.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 2:
                areaFireObject.transform.eulerAngles = new Vector3(0, 270, 0);
                break;
            case 3:
                areaFireObject.transform.eulerAngles = new Vector3(0, 90, 0);
                break;
        }
        
        for (int i = 0; i < 9; i++)
        {
            GameObject temp = Instantiate(Bullet, areaFirePos[i].transform.position, areaFirePos[i].transform.rotation) as GameObject;
            
            temp.GetComponent<Bullet>().moveSpeed = 5;
            temp.GetComponent<Bullet>().damagePoint = normalDamagePoint/2;
            temp.GetComponent<Bullet>().teamType = unitBase.teamType;
            temp.GetComponent<Bullet>().limitValue = 3;
        }
    }
    
    public void Hit()
    {
        UI_Object.GetComponent<UI>().HeartUpdate(unitBase.HP);
        timeV2 = 0.5f;
        animator.SetBool("Hit", true);
    }

    public void Dead()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Shot", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Dead", true);
    }

    void Search()
    {
        if (animator.GetBool("Move") == false)
        {
            Collider[] cols = Physics.OverlapBox(gameObject.transform.position, new Vector3(20, 1, 20));

            foreach (Collider col in cols)
                if (unitBase.teamType != col.gameObject.GetComponent<UnitBase>().teamType && col.gameObject.GetComponent<UnitBase>().teamType != 0 && col.gameObject.GetComponent<UnitBase>().unitType != 0)
                {
                    firePos.transform.LookAt(col.transform.position);
                    Shot();
                    break;
                }
        }

        if (berserkerOn == true)
        {
            Collider[] cols = Physics.OverlapBox(gameObject.transform.position, new Vector3(0.5f, 1, 0.5f));

            foreach (Collider col in cols)
                if (unitBase.teamType != col.gameObject.GetComponent<UnitBase>().teamType && col.gameObject.GetComponent<UnitBase>().teamType != 0 && col.gameObject.GetComponent<UnitBase>().unitType != 0)
                {
                    
                    col.gameObject.GetComponent<UnitBase>().Hit(1);
                    break;
                }
        }
    }
}
