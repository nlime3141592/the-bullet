using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIopener
{
    // UI 탐색 및 제거, 반환변수설정, 개념로드, 실제생성, 초기화, 반환
    // 회화창을 여는 함수
    public GameObject Open_ConversationUI(Icon icon, string message, int button_count)
    {
        // UI 탐색 및 제거
        UIcloser.closeConversation();

        // 반환할 변수 생성
        GameObject convUI = null;

        // 오브젝트 개념상 로드
        string path = "Prefabs/UI/ConversationUI";
        GameObject objload = Resources.Load(path) as GameObject;

        // 오브젝트 실제 생성
        convUI = GameObject.Instantiate(objload, Vector3.zero, Quaternion.identity);
        GameObject Canvas = GameObject.Find("Canvas_A");
        convUI.transform.SetParent(Canvas.transform, false);

        // 초기화
        convUI.GetComponent<ConversationUI>().ConversationInitialize(message, button_count);

        // 반환
        return convUI;
    }

    // 옵션창을 여는 함수
    public GameObject Open_OptionUI()
    {
        UIcloser.closeOption();

        string path = "Prefabs/UI/Canvas_Option";

        GameObject load = Resources.Load(path) as GameObject;

        GameObject optionUI = GameObject.Instantiate(load, Vector3.zero, Quaternion.identity);

        GameObject Canvas = GameObject.Find("Canvas_A");

        optionUI.transform.SetParent(Canvas.transform, false);

        return optionUI;
    }

    public GameObject Open_gameUI(string phase)
    {
        UIcloser.closeAll();

        GameObject gameUI = null;

        // 게임 시작
        //string path = "Prefabs/UI/Canvas_Game";
        //GameObject load = Resources.Load(path) as GameObject;

        //GameObject instant = GameObject.Instantiate(load, Vector3.zero, Quaternion.identity);
        //GameObject Canvas = GameObject.Find("Canvas_A");

        //instant.transform.SetParent(Canvas.transform, false);

        //gameUI = instant;

        //gameUI.GetComponent<GameUI>().GameInitialize();

        //switch (phase)
        //{
        //    case "start":
        //        gameUI.GetComponent<GameUI>().GameClear();
        //        break;

        //    case "continue":
        //        gameUI.GetComponent<GameUI>().GameContinue();
        //        break;
        //}

        return gameUI;
    }

    public GameObject Open_MenuUI()
    {
        // UI 탐색 및 제거
        UIcloser.closeAll();

        // 반환할 오브젝트
        GameObject menuUI = null;

        // Canvas 개념상 로드
        string path = "Prefabs/UI/Canvas_Main";
        GameObject load = Resources.Load(path) as GameObject;

        // 실제 생성
        GameObject instant = GameObject.Instantiate(load, Vector3.zero, Quaternion.identity);
        GameObject Canvas = GameObject.Find("Canvas_A");
        instant.transform.SetParent(Canvas.transform, false);

        // 초기화
        instant.GetComponent<UIcomponent>().Initialize();

        // 반환
        menuUI = instant;
        return menuUI;
    }

    public GameObject Open_GameEndUI()
    {
        UIcloser.closeGameEnd();
        UIcloser.closeGame();

        string path = "Prefabs/UI/Canvas_GameEnd";
        GameObject load = Resources.Load(path) as GameObject;

        GameObject instant = GameObject.Instantiate(load, Vector3.zero, Quaternion.identity);
        GameObject Canvas = GameObject.Find("Canvas_A");

        instant.transform.SetParent(Canvas.transform, false);

        instant.GetComponent<GameEndUI>().ShowRecord();

        return instant;
    }

    public GameObject Open_PauseUI()
    {
        int t = 0;
        foreach(PauseUI pui in GameObject.FindObjectsOfType<PauseUI>())
        {
            t++;
        }

        GameObject pauseUI = null;
        if (t == 0)
        {
            string path = "Prefabs/UI/Canvas_Pause";
            GameObject load = Resources.Load(path) as GameObject;

            // 오브젝트 실제 생성
            GameObject instant = GameObject.Instantiate(load, Vector3.zero, Quaternion.identity);
            GameObject Canvas = GameObject.Find("Canvas_A");
            instant.transform.SetParent(Canvas.transform, false);

            pauseUI = instant;
        }

        return pauseUI;
    }

    public GameObject Open_ThemeUI()
    {
        // UI 탐색 및 제거, 반환변수설정, 개념로드, 실제생성, 초기화, 반환
        // UI 탐색 및 제거
        UIcloser.closeTheme();

        // 반환변수설정
        GameObject themeUI = null;

        // 오브젝트 개념 로드
        string path = "Prefabs/UI/Canvas_Theme";
        GameObject load = Resources.Load(path) as GameObject;

        // 오브젝트 실제 생성
        GameObject instant = GameObject.Instantiate(load, Vector3.zero, Quaternion.identity);
        GameObject Canvas = GameObject.Find("Canvas_A");
        instant.transform.SetParent(Canvas.transform, false);

        // 반환
        themeUI = instant;
        return themeUI;
    }

    public GameObject Open_Textbox(string type)
    {
        UIcloser.closeTextbox();

        GameObject UI = null;

        string path = "Prefabs/UI/Canvas_";
        switch(type)
        {
            case "develop":
                path += "Develop";
                break;
            case "htp":
                path += "HowToPlay";
                break;
            case "copyright":
                path += "Copyright";
                break;
        }
        GameObject load = Resources.Load(path) as GameObject;

        GameObject instant = GameObject.Instantiate(load, Vector3.zero, Quaternion.identity);
        GameObject canvas = GameObject.Find("_Option");
        instant.transform.SetParent(canvas.transform, false);

        UI = instant;
        return UI;

    }

    public GameObject Open_ContinueUI()
    {
        ClearUI();

        GameObject result = null;

        string path = "Prefabs/UI/Canvas_Continue";
        GameObject obj = Resources.Load(path) as GameObject;

        GameObject instant = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);
        GameObject canv = GameObject.Find("Canvas_A");

        instant.transform.SetParent(canv.transform, false);

        result = instant;

        return result;
    }

    // 열려있는 모든 캔버스를 닫는 메소드
    public void ClearUI()
    {
        foreach(UIcomponent ui in GameObject.FindObjectsOfType<UIcomponent>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }
}
