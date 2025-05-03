using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen
{
    public Image screenimg;

    // 1 - 페이드 on 상태
    // 0 - 페이드 off 상태
    public float screenTransparent = 1;

    // 모노비헤이비어 스크립트를 가지고 있는 게임오브젝트를 찾아서 대입해야함.
    private MonoBehaviour mb = GameObject.Find("ManageObject").GetComponent<MonoBehaviour>();

    private float fadespeed = 1;

    public FadeScreen(float fade_speed)
    {
        fadespeed = fade_speed;
    }

    public void screenInitializing()
    {
        Color c = screenimg.color;

        screenimg.color = new Color(c.r, c.b, c.g, screenTransparent);
    }

    public void FadeIn()
    {
        mb.StartCoroutine(fin());
    }

    public void FadeOut()
    {
        mb.StartCoroutine(fout());
    }

    IEnumerator fin()
    {
        screenimg.raycastTarget = true;

        while (screenTransparent < 1)
        {
            screenTransparent += Time.deltaTime * fadespeed;

            Color c = screenimg.color;

            screenimg.color = new Color(c.r, c.b, c.g, screenTransparent);

            screenTransparent = Mathf.Clamp01(screenTransparent);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator fout()
    {
        while (screenTransparent > 0)
        {
            screenTransparent -= Time.deltaTime * fadespeed;

            Color c = screenimg.color;

            screenimg.color = new Color(c.r, c.b, c.g, screenTransparent);

            screenTransparent = Mathf.Clamp01(screenTransparent);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        screenimg.raycastTarget = false;
    }

    public string FadeStatus()
    {
        switch(screenTransparent)
        {
            case 1:
                return "fadein";
            case 0:
                return "fadeout";
            default:
                return "fading";
        }
    }
}
