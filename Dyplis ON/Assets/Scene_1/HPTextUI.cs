using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPTextUI : MonoBehaviour
{
    public GameObject[] hp;
    public Image hpUI;
    UnitBase ub;
    bool uiOn;
    // Start is called before the first frame update
    void Start()
    {
        ub = GetComponent<UnitBase>();
    }

    // Update is called once per frame
    void Update()
    {
        HPUPDATE();
    }

    void HPUPDATE()
    {
        
        if (ub.HP < ub.HP_MAX && uiOn == false)
        {
            hp[0].SetActive(true);
            hp[1].SetActive(true);
            uiOn = true;
        }

        if(uiOn == true)
        {
            hpUI.fillAmount = ub.HP / ub.HP_MAX;
        }
    }
}
