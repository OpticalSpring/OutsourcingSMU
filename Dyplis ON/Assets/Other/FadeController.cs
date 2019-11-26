using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public bool Set;

    private void Start()
    {
        if (Set)
        {

        } else
        FadeOut(3);
    }
    public void FadeIn(float fadeOutTime, int i)
    {
        StartCoroutine(CoFadeIn(fadeOutTime, i));
    }

    public void FadeOut(float fadeOutTime)
    {
        StartCoroutine(CoFadeOut(fadeOutTime));
    }

    // 투명 -> 불투명
    IEnumerator CoFadeIn(float fadeOutTime, int i)
    {
       SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        
        Color tempColor = sr.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;

            yield return null;
        }

        sr.color = tempColor;
        if (Set)
        {

        }
        else
        {
            Camera.main.transform.GetChild(0).gameObject.GetComponent<SaveManager>().DataSave();
            SceneManager.LoadSceneAsync(i);
        }
    }

    // 불투명 -> 투명
    IEnumerator CoFadeOut(float fadeOutTime)
    {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        Color tempColor = sr.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        sr.color = tempColor;
        
    }


}
