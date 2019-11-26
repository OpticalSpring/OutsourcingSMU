using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunPlayer : MonoBehaviour
{
    public float speed;
    Vector3 outPos;
    public float roadLength;
    public int coinCount;
    public int HP;
    public GameObject characterObject;
    public Text[] textUI;
    public Image hpImage;
   public int localPos;
   public Vector3[] targetPos;
    public float localMovementSpeed;
    public bool tileRotate;
    public bool slideValue, jumpValue, hitValue;
    public float slideTime, jumpTime, hitTime;
    public Animator charAnimator;
    public float jumpPower;
    public bool Set;
    public float lifeTime, lifeTImeSet;
    public int coinCountHP;
    int ci = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 0)
        {
            SpeedUp();
            Run();
            Slide();
            Jump();
            LocalMove();
            LengthCheck();
            FallCheck();
            TimeOut();
            UpdateUI();
        }
        else
        {
            if(Set == false)
            {
                Set = true;
                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataLoad();
                int a = Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataFloor;
                a++;
                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().dataFloor = a;


                if(roadLength > Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().distance)
                {
                    Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().distance = (int)roadLength;
                    Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().ticket += 1;
                }

                Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataSave()
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        ;
                Camera.main.transform.GetChild(0).gameObject.GetComponent<FadeController>().FadeIn(3, 1);
            }
        }
    }

    void Run()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void LengthCheck()
    {
        roadLength += Vector3.Distance(transform.position, outPos);
        outPos = transform.position;
    }

    void UpdateUI()
    {
        textUI[0].text = (int)roadLength+" m";
        textUI[1].text = "Coin " + coinCount;
        textUI[2].text = "체력 : " + HP;
        hpImage.fillAmount = (float)HP / 100;
    }

    void SpeedUp()
    {
        speed += Time.deltaTime;
    }


    void FallCheck()
    {
        if (characterObject.transform.position.y < 0)
        {
            HP = 0;
        }
    }


    void LocalMove()
    {
        if (tileRotate == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (localPos > 0)
                    localPos--;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (localPos < 2)
                    localPos++;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && slideValue == false)
            {
                slideValue = true;
                slideTime = 1;
                charAnimator.SetBool("Slide", true);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && jumpValue == false)
            {
                jumpValue = true;
                jumpTime = 1;
                charAnimator.SetBool("Jump", true);
                characterObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
        

        characterObject.transform.localPosition = Vector3.Lerp(characterObject.transform.localPosition, targetPos[localPos], localMovementSpeed*Time.deltaTime);
    }


    void Slide()
    {
        if (slideTime > 0)
        {
            slideTime -= Time.deltaTime;
        }
        else
        {
            slideValue = false;
            charAnimator.SetBool("Slide", false);
        }
    }

    void Jump()
    {
        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }
        else
        {
            jumpValue = false;
            charAnimator.SetBool("Jump", false);
        }
    }

    void TimeOut()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            lifeTime = lifeTImeSet;
            HP-=5;
        }

        coinCountHP = coinCount;
        if(coinCountHP >= 10 * ci)
        {
            ci++;
            HP+=5;
        }
    }
}
