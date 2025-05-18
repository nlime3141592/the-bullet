using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _Button : Icon
{
    public override void OnBeginDrag(PointerEventData pad)
    {
        draged = true;
        base.OnBeginDrag(pad);
    }

    public override void OnDrag(PointerEventData pad)
    {
        base.OnDrag(pad);
    }

    public override void OnScroll(PointerEventData pad)
    {
        base.OnScroll(pad);
    }

    public override void OnEndDrag(PointerEventData pad)
    {
        base.OnEndDrag(pad);
    }

    public override void OnPointerUp(PointerEventData pad)
    {
        if (draged == false)
        {
            func();
        }
        draged = false;
    }

    // 구글 애드몹을 적용 안했을때 restart 케이스에 넣을 테스트용 함수
    void ContinueUIShow()
    {
        GameObject ui = new UIopener().Open_ContinueUI();
    }

    void func()
    {
        switch (function)
        {
            case "conv_ok":
                GameObject.FindObjectOfType<ConversationUI>().event_ok();
                break;

            case "conv_yes":
                GameObject.FindObjectOfType<ConversationUI>().event_yes();
                break;

            case "conv_no":
                GameObject.FindObjectOfType<ConversationUI>().event_no();
                break;

            case "theme_open":
                //GameObject shopUI = new UIopener().Open_ThemeUI();
                GameObject.FindObjectOfType<MainUI>().screenindex = GameObject.FindObjectOfType<ThemeUI>().screenindex;
                GameObject.FindObjectOfType<MainUI>().restrict = true;
                break;

            case "theme_exit":
                //UIcloser.closeTheme();
                GameObject.FindObjectOfType<MainUI>().screenindex = 1;
                GameObject.FindObjectOfType<MainUI>().restrict = true;
                break;

            case "open_option":
                //GameObject optionUI = new UIopener().Open_OptionUI();
                GameObject.FindObjectOfType<MainUI>().screenindex = 0;
                GameObject.FindObjectOfType<MainUI>().restrict = true;
                break;

            case "close_option":
                //UIcloser.closeOption();
                GameObject.FindObjectOfType<MainUI>().screenindex = 1;
                GameObject.FindObjectOfType<MainUI>().restrict = true;
                break;

            case "gamestart_option":
                //GameObject.FindObjectOfType<MainScene>().Set_GameStatus(false);
                //foreach (Player p in GameObject.FindObjectsOfType<Player>())
                //{ Destroy(p.gameObject); }
                //new SceneLoader().Generation_Player();
                //GameObject gameUI_1 = new UIopener().Open_gameUI("start");
                break;

            case "gamestart":
                GameObject gameUI_2 = new UIopener().Open_gameUI("start");
                break;

            case "showad":
                //GameObject.FindObjectOfType<MainScene>().Set_GameStatus(false);
                //foreach (Player p in GameObject.FindObjectsOfType<Player>())
                //{ Destroy(p.gameObject); }
                //GameObject.FindObjectOfType<RewardAds>().ShowAds();
                //ContinueUIShow(); // 테스트용
                break;

            case "continue":
                Time.timeScale = 1;
                GameObject.FindObjectOfType<SoundControl>().RewardAdsOpened = 1;
                new SceneLoader().Generation_Player();
                GameObject gameUI_3 = new UIopener().Open_gameUI("continue");
                break;

            case "close_pause":
                //GameObject.FindObjectOfType<MainScene>().GamePausing();
                break;

            case "open_menu":
                GameObject menuUI = new UIopener().Open_MenuUI();
                break;

            case "fix_joystick":
                bool t = DataValue.valueJoystickFixed();
                t = !t;
                DataChanger.setJoystickFixed(t);
                break;

            case "howtoplay":
                new UIopener().Open_Textbox("htp");
                break;

            case "developer":
                new UIopener().Open_Textbox("develop");
                break;

            case "copyright":
                new UIopener().Open_Textbox("copyright");
                break;

            case "close_textbox":
                UIcloser.closeTextbox();
                break;

            case "leaderboard":
                GPGSUI.OpenLeaderBoard();
                break;

            case "achivementboard":
                GPGSUI.OpenAchivementBoard();
                break;

            case "frontmode":
                GameObject.FindObjectOfType<GameModeDisplayer>().modechange_front();
                break;

            case "backmode":
                GameObject.FindObjectOfType<GameModeDisplayer>().modechange_back();
                break;
        }
    }
}