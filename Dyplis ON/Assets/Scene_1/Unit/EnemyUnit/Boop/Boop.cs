using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boop : MonoBehaviour
{
    enum Rotation
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    enum STATE
    {
        IDLE,
        ATTACK,
        Skill
    }
    STATE state = STATE.IDLE;
    Rotation rotation = Rotation.DOWN;

    UnitBase unitBase;
    Animator animator;
    public float damagePoint;
    float timeV = 0;
    float timeValue = 0;
    public float movementSpeed2;
    bool Set = false;
    GameObject FP;
    bool FPSET;
    public GameObject warningObj;
    bool of;
    void Start()
    {
        FP = GameObject.Find("FP");
        unitBase = GetComponent<UnitBase>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        StartCoroutine(StartSet());
    }

    IEnumerator StartSet()
    {
       
        yield return new WaitForSeconds(1f);
        Set = true;
        animator.SetBool("Start", true);
        
    }

    IEnumerator SpawnFP()
    {
        state = STATE.Skill;
        int r = Random.Range(0, 4);
        FP.transform.GetChild(r).gameObject.SetActive(true);
        animator.SetInteger("State", 3);
        yield return new WaitForSeconds(5f);
        state = STATE.IDLE;
    }


    // Update is called once per frame
    void Update()
    {
        if (unitBase.HP > 0)
        {
            if (Set)
            {
                ModeChange();
                switch (state)
                {
                    case STATE.IDLE:
                        of = false;
                        Search();
                        warningObj.SetActive(false);
                        break;
                    case STATE.ATTACK:
                        if (of == false)
                        {
                            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(3);
                            of = true;
                        }
                        Search();
                        Attack();
                        bomb();
                        warningObj.SetActive(true);
                        break;
                    case STATE.Skill:

                    default:
                        break;
                }
                Debug.Log(state);
            }
            else
            {
                
            }

        }
    }

    void Search()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.up, out hit, 0);
        switch (rotation)
        {
            case Rotation.UP:
                Physics.Raycast(transform.position, Vector3.forward, out hit, 3);
                gameObject.transform.Translate(Vector3.forward * unitBase.movementSpeed * Time.deltaTime);

                break;
            case Rotation.DOWN:
                Physics.Raycast(transform.position, Vector3.back, out hit, 3);
                gameObject.transform.Translate(Vector3.back * unitBase.movementSpeed * Time.deltaTime);

                break;
            case Rotation.LEFT:
                Physics.Raycast(transform.position, Vector3.left, out hit, 3);
                gameObject.transform.Translate(Vector3.left * unitBase.movementSpeed * Time.deltaTime);

                break;
            case Rotation.RIGHT:
                Physics.Raycast(transform.position, Vector3.right, out hit, 3);
                gameObject.transform.Translate(Vector3.right * unitBase.movementSpeed * Time.deltaTime);

                break;
        }

        RaycastHit hit2;
        Physics.Raycast(transform.position, Vector3.up, out hit2, 0);
        switch (rotation)
        {
            case Rotation.UP:
                Physics.Raycast(transform.position, Vector3.forward, out hit2, 0.5f);
                break;
            case Rotation.DOWN:
                Physics.Raycast(transform.position, Vector3.back, out hit2, 0.5f);
                break;
            case Rotation.LEFT:
                Physics.Raycast(transform.position, Vector3.left, out hit2, 0.5f);
               break;
            case Rotation.RIGHT:
                Physics.Raycast(transform.position, Vector3.right, out hit2, 0.5f);
                break;
        }

        if (hit.rigidbody != null)
        {
            if (hit.collider.gameObject.GetComponent<UnitBase>().teamType != GetComponent<UnitBase>().teamType && hit.collider.gameObject.GetComponent<UnitBase>().unitType != 0)
            {
                state = STATE.ATTACK;
                timeValue = 0;
                animator.SetInteger("State", 2);
            }

        }

        if (hit2.rigidbody != null)
        {
            if (hit2.collider.gameObject.GetComponent<UnitBase>().teamType == 0)
            {
                state = STATE.IDLE;
                timeValue = 1;
                ModeChange();
                animator.SetInteger("State", 1);
            }

        }


    }

    void Attack()
    {

        switch (rotation)
        {
            case Rotation.UP:
                gameObject.transform.Translate(Vector3.forward * movementSpeed2 * Time.deltaTime);
                break;
            case Rotation.DOWN:
                gameObject.transform.Translate(Vector3.back * movementSpeed2 * Time.deltaTime);
                break;
            case Rotation.LEFT:
                gameObject.transform.Translate(Vector3.left * movementSpeed2 * Time.deltaTime);
                break;
            case Rotation.RIGHT:
                gameObject.transform.Translate(Vector3.right * movementSpeed2 * Time.deltaTime);
                break;
        }
    }

    
    void ModeChange()
    {
        timeValue += Time.deltaTime;

        if (FPSET == false && unitBase.HP <= 10)
        {
            FPSET = true;
            StartCoroutine(SpawnFP());
        }
        switch (state)
        {
            case STATE.IDLE:
                if (timeValue > 0.8)
                {
                    timeValue = 0;
                    int randomValue = Random.Range(0, 4);
                    switch (randomValue)
                    {
                        case 0:
                            rotation = Rotation.UP;
                            animator.SetInteger("Rotation", 0);
                            break;
                        case 1:
                            rotation = Rotation.DOWN;
                            animator.SetInteger("Rotation", 1);
                            break;
                        case 2:
                            rotation = Rotation.LEFT;
                            animator.SetInteger("Rotation", 2);
                            break;
                        case 3:
                            rotation = Rotation.RIGHT;
                            animator.SetInteger("Rotation", 3);
                            break;
                    }
                }
                break;
            case STATE.ATTACK:
                if (timeValue > 0.8)
                {
                    state = STATE.IDLE;
                    timeValue = 0;
                }
                break;
        }
    }


    void bomb()
    {
        if (timeV <= 0)
        {
            Collider[] cols = Physics.OverlapBox(gameObject.transform.position, new Vector3(0.5f, 0.5f, 0.5f));

            foreach (Collider col in cols)
                if (unitBase.teamType != col.gameObject.GetComponent<UnitBase>().teamType && col.gameObject.GetComponent<UnitBase>().teamType != 0)
                {
                    col.gameObject.GetComponent<UnitBase>().Hit(damagePoint);
                    timeV = 1;
                }
        }
        else
        {
            timeV -= Time.deltaTime;
        }
    }


    public void Dead()
    {
        animator.SetInteger("State", 0);
        Destroy(gameObject, 1);


    }


    public void Hit()
    {

    }






}
