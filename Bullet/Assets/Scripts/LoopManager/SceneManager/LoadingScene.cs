using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LoadingScene : LoopStation
{
    FadeScreen fs;

    protected override void Initialize()
    {
        // 구글플레이서비스를 사용할 수 있게 로딩
        //GPGSUI.EnableGPGS();

        versionCheck();

        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        GameObject bgm = GameObject.Find("Audio_BGM");

        DontDestroyOnLoad(bgm);

        fs = new FadeScreen(2);
        fs.screenTransparent = 0;
        fs.screenimg = GameObject.Find("Logo").GetComponent<Image>();

        yield return new WaitForSeconds(1f);

        fs.FadeIn();

        yield return new WaitUntil(() => fs.FadeStatus() == "fadein");

        // 페이드인 되면 GPGS에서 자동로그인을 요청
        //GPGSUI.OpenAutoLogin();

        yield return new WaitForSeconds(3f);

        fs.FadeOut();

        yield return new WaitUntil(() => fs.FadeStatus() == "fadeout");
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadSceneAsync("Main");
    }

    protected override void Loop()
    {

    }

    void versionCheck()
    {
        ClearData.UpdateCheck();
    }
}
