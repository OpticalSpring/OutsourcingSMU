using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
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
        ATTACK
    }
    STATE state = STATE.IDLE;
    Rotation rotation = Rotation.DOWN;

    UnitBase unitBase;
    float timeValue = 0;
    float timeValue2 = 0;
    bool wt;

    public GameObject spriteObject;
    Animator animator;
    public float damagePoint;
    float timeV = 0;

    public float movementSpeed2;

    public GameObject warningObj;
    // Start is called before the first frame update
    void Start()
    {
        unitBase = GetComponent<UnitBase>();
        animator = transform.GetChild(0).GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (unitBase.HP > 0)
        {
            ModeChange();
            switch (state)
            {
                case STATE.IDLE:
                    Search();
                    break;
                case STATE.ATTACK:
                    Search();
                    Attack();
                    bomb();
                    break;
                default:
                    break;
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
                //gameObject.transform.Translate(Vector3.forward * unitBase.movementSpeed * Time.deltaTime);
                break;
            case Rotation.DOWN:
                Physics.Raycast(transform.position, Vector3.back, out hit2, 0.5f);
                //.transform.Translate(Vector3.back * unitBase.movementSpeed * Time.deltaTime);
                break;
            case Rotation.LEFT:
                Physics.Raycast(transform.position, Vector3.left, out hit2, 0.5f);
                // gameObject.transform.Translate(Vector3.left * unitBase.movementSpeed * Time.deltaTime);
                break;
            case Rotation.RIGHT:
                Physics.Raycast(transform.position, Vector3.right, out hit2, 0.5f);
                // gameObject.transform.Translate(Vector3.right * unitBase.movementSpeed * Time.deltaTime);
                break;
        }

        if (hit.rigidbody != null)
        {
            if (hit.collider.gameObject.GetComponent<UnitBase>().teamType != GetComponent<UnitBase>().teamType && hit.collider.gameObject.GetComponent<UnitBase>().unitType != 0)
            {
                warningObj.SetActive(true);
                timeValue = 0;
                if (wt == false)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(0);
                    wt = true;
                    timeValue2 = 0;
                }
                state = STATE.ATTACK;
            }

        }

        if (hit2.rigidbody != null)
        {
            if (hit2.collider.gameObject.GetComponent<UnitBase>().teamType == 0)
            {
                state = STATE.IDLE;
                timeValue = 3;
                ModeChange();
                animator.SetBool("Shot", false);
            }

        }


    }

    void Attack()
    {
        if (timeValue2 > 2)
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
        timeValue2 += Time.deltaTime;
        switch (state)
        {
            case STATE.IDLE:
                warningObj.SetActive(false);
                if (timeValue > 2)
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
                if (timeValue > 2)
                {
                    animator.SetBool("Shot", true);
                }
                if (timeValue > 4)
                {
                    state = STATE.IDLE;
                    timeValue = 0;
                    wt = false;
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

    public void Hit()
    {

    }

    public void Dead()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Shot", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Dead", true);
        Destroy(gameObject, 1);


    }


}
