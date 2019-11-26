using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    GameManager gameManager;
    public GameObject managerObject;
    bool open;
    Animator animator;
    private void Start()
    {
        gameManager = managerObject.GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            if (gameManager.roomClear == true)
            {
                animator.SetBool("Open", true);
            }
            else
            {
                animator.SetBool("Open", false);
            }
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { 
            gameManager.NextRoom();
        }
    }
}
