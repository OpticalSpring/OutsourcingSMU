using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revenant : MonoBehaviour
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
        MOVE,
        ATTACK
    }
    STATE state = STATE.MOVE;
    Rotation rotation = Rotation.UP;

    UnitBase unitBase;

    public GameObject spriteObject;
    Animator animator;
    public float damagePoint;
    public float timeV;
    public float movementSpeed;
    public Vector3[] movePoint;
    public GameObject bullet;
    public int mapType;
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

            bomb();
            switch (state)
            {
                case STATE.IDLE:

                    break;
                case STATE.MOVE:
                    Move();
                    break;
                case STATE.ATTACK:

                    break;
            }
        }
    }

    void Idle()
    {

    }
    
    void Move()
    {
        switch (rotation)
        {
            case Rotation.UP:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(movePoint[mapType * 2].x, 1, movePoint[mapType * 2].z), Time.deltaTime * movementSpeed);
                if(Vector3.Distance(gameObject.transform.position, new Vector3(movePoint[mapType*2].x, 1, movePoint[mapType * 2].z)) < 0.1)
                {
                    state = STATE.IDLE;
                    StartCoroutine("MoveDelay");
                }
                break;
            case Rotation.DOWN:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(movePoint[mapType * 2 + 1].x, 1, movePoint[mapType * 2 + 1].z), Time.deltaTime * movementSpeed);
                if (Vector3.Distance(gameObject.transform.position, new Vector3(movePoint[mapType * 2 + 1].x, 1, movePoint[mapType * 2 + 1].z)) < 0.1)
                {
                    state = STATE.IDLE;
                    StartCoroutine("MoveDelay");
                }
                break;
            case Rotation.LEFT:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(movePoint[mapType * 2].x, 1, movePoint[mapType * 2 + 1].z), Time.deltaTime * movementSpeed);
                if (Vector3.Distance(gameObject.transform.position, new Vector3(movePoint[mapType * 2].x, 1, movePoint[mapType * 2 + 1].z)) < 0.1)
                {
                    state = STATE.IDLE;
                    StartCoroutine("MoveDelay");
                }
                break;
            case Rotation.RIGHT:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(movePoint[mapType * 2 + 1].x, 1, movePoint[mapType * 2].z), Time.deltaTime * movementSpeed);
                if (Vector3.Distance(gameObject.transform.position, new Vector3(movePoint[mapType * 2 + 1].x, 1, movePoint[mapType * 2].z)) < 0.1)
                {
                    state = STATE.IDLE;
                    StartCoroutine("MoveDelay");
                }
                break;
        }
    }

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(2f);
        switch (rotation)
        {
            case Rotation.UP:
                rotation = Rotation.RIGHT;
                animator.SetInteger("Rotation", 3);
                break;
            case Rotation.DOWN:
                rotation = Rotation.LEFT;
                animator.SetInteger("Rotation", 2);
                break;
            case Rotation.LEFT:
                rotation = Rotation.UP;
                animator.SetInteger("Rotation", 0);
                break;
            case Rotation.RIGHT:
                rotation = Rotation.DOWN;
                animator.SetInteger("Rotation", 1);
                break;
        }
        animator.SetBool("Shot", true);
        Attack();
        yield return new WaitForSeconds(0.2f);
        Attack();
        yield return new WaitForSeconds(0.2f);
        Attack();
        animator.SetBool("Shot", false);
        state = STATE.MOVE;
    }

    void Attack()
    {
                GameObject temp = Instantiate(bullet);
        temp.transform.position = gameObject.transform.position;
            switch (rotation)
            {
                case Rotation.UP:
                temp.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case Rotation.DOWN:
                temp.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
                case Rotation.LEFT:
                temp.transform.eulerAngles = new Vector3(0, 270, 0);
                break;
                case Rotation.RIGHT:
                temp.transform.eulerAngles = new Vector3(0, 90, 0);
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
