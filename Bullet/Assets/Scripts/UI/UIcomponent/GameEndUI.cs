using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : UIcomponent
{
    public Animator NowAnimation;
    public Animator BestAnimation;
    public Animator ButtonAnimation;
    public Animator ADanimation;

    //MainScene main;

    public void ShowRecord()
    {
        //main = GameObject.FindObjectOfType<MainScene>();

        ButtonAnimation = GetComponent<Animator>();
        foreach(Animator a in GetComponentsInChildren<Animator>())
        {
            switch(a.name)
            {
                case "UI_Now":
                    NowAnimation = a;
                    continue;
                case "UI_Best":
                    BestAnimation = a;
                    continue;
                case "Icon_AD":
                    ADanimation = a;
                    continue;
            }
        }

        // 점수 기록
        //main.GetGameMode().Recording_GameEndUI();
    }

    public void PlayAnimation_NowScore()
    {
        NowAnimation.Play("PlayNow");
    }

    public void PlayAnimation_BestScoreAndText()
    {
        BestAnimation.Play("PlayBest");
    }

    public void PlayAnimation_OpenButton()
    {
        ButtonAnimation.Play("OpenButton");
    }

    //public void PlayAD()
    //{
    //    if (main.GetGameMode().ADwatched == false)
    //    {
    //        main.GetGameMode().SetADwatched(true);
    //        ADanimation.Play("OpenAD");
    //    }
    //}

    // ShowRecord 안에 들어가는 AnimationEvent
    public void AfterAnimation()
    {
        //StartCoroutine(main.GetGameMode().OverCombo1());
    }

    IEnumerator BestScoreDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Clear New Score.");
        NowAnimation.Play("NewScore");
    }

    public void SetScoreboardMessage(string m1, string m2)
    {
        foreach (Text txt in gameObject.GetComponentsInChildren<Text>())
        {
            string name = txt.gameObject.name;

            switch (name)
            {
                case "Scoreboard_Now":
                    txt.text = m1;
                    continue;

                case "Scoreboard_Best":
                    txt.text = m2;
                    continue;
            }
        }
    }
}