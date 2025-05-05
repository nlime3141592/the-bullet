//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//// Main Scene을 조정하기 위한 클래스
//public class MainScene : LoopStation
//{
//    // 게임 시작 여부
//    private bool gameStart = false;

//    // 게임이 끝났는지 여부
//    private bool gameEnd = false;

//    // 플레이어가 게임을 실행했을 경우 적용할 게임 모드
//    GameMode gamemode;

//    public bool dataclear = false; // 신경 안써도 됨

//    // 색깔을 변경하기 위해 사용했던 클래스
//    // 게임 진행 마다 테마별로 정해진 6~7가지의 색깔들이 배경 색으로 적용되고 이것들이 계속 변경되었음.
//    public SkyboxColorMix colorMix;

//    // 페이드를 위한 가림막 클래스
//    FadeScreen fs; // Bullet 프로젝트 당시에 페이스 스크린 스크립트에서 상당히 많은 문제가 발생했었음. 스크립트 제공 따로 안함.

//    // 초기화를 위한 함수
//    protected override void Initialize()
//    {
//        DataLoading();

//        gamemode = new ChangeGameMode().Normal();

//        SetBGM();
//        SetEffect();

//        StartCoroutine(Generation_Integrated());

//        colorMix = new SkyboxColorMix();
//        colorMix.ResetColor();

//        new UIopener().Open_MenuUI();

//        fs = new FadeScreen(2);
//        fs.screenimg = GameObject.Find("Canvas_Fade").GetComponent<Image>();

//        fs.FadeOut();
//    }

//    public bool test = false;
//    // 반복을 위한 함수
//    protected override void Loop()
//    {
//        if (test == true)
//        {
//            test = false;
//            new UIopener().Open_ContinueUI();
//        }

//        if (dataclear == true)
//        {
//            dataclear = false;
//            // 데이터 초기화 함수, 테스트할때만 초기화하기
//            ClearData.ResetDatas();
//        }

//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            GamePausing();
//        }

//        ComboBreaker();
//        AddScore();
//        PlayerDied();

//        colorMix.ChangeColor();

//        if(gameStart == false)
//        {
//            foreach(Bullet b in GameObject.FindObjectsOfType<Bullet>())
//            {
//                Destroy(b.gameObject);
//            }
//        }
//    }

//    // 총알과 경고선 생성
//    IEnumerator Generation_Integrated()
//    {
//        while(true)
//        {
//            yield return new WaitWhile(() => gameStart == false); // 게임 시작 여부를 알려주는 변수가 false인 동안 이곳에서 정지

//            new SceneLoader().Generation_Integrated(); // SceneLoader의 Generation 함수를 이용하여 다양한 오브젝트 생성

//            // 일정 주기마다 총알을 생생해야 한다.
//            // 일정 주기는 플레이어가 쌓은 점수에 비례하여 점점 짧아져야 한다(난이도 상승)
//            // CustomVariable 클래스는 
//            yield return new WaitForSeconds(CustomVariable.Delay_Generation_Integrated(gamemode.score)); 
//        }
//    }

//    // 점수 기록
//    void AddScore()
//    {
//        if(gameStart == true)
//        {
//            GameObject.Find("Textbox_NowScore").GetComponent<Text>().text = gamemode.displayvalue;
//        }
//    }

//    // 콤보 브레이커
//    void ComboBreaker()
//    {
//        if (gameStart == true)
//        {
//            if (gamemode.combo_tick > 0)
//            {
//                gamemode.ReupdateComboTick();

//                if (gamemode.combo_tick < 0)
//                {
//                    gamemode.SetComboTick(0);
//                    gamemode.SetCombo(0);
//                    GameObject.Find("Textbox_ComboText").GetComponent<Animator>().Play("Zero");
//                    Debug.Log("콤보 파괴");
//                }
//            }
//        }
//    }

//    // 플레이어가 죽었을 때 실행되는 이벤트
//    public void Set_GameEnd()
//    {
//        gameEnd = true;
//    }
//    void PlayerDied()
//    {
//        if(gameEnd == true)
//        {
//            gameEnd = false;
//            StartCoroutine(EndDelay());
//        }
//    }
//    IEnumerator EndDelay()
//    {
//        yield return new WaitForSeconds(2f);

//        GameObject endUI = new UIopener().Open_GameEndUI();
//    }


//    // 배경음악을 설정하는 함수
//    void SetBGM()
//    {
//        AudioSource bgm = GameObject.Find("Audio_BGM").GetComponent<AudioSource>();

//        bgm.volume = DataValue.valueBGM();

//        string theme = DataValue.valueTheme();
//        string path = "Audio/ThemeAudio/ThemeAudio_" + theme;

//        AudioClip clip = Resources.Load(path) as AudioClip;

//        if (bgm.clip == null || bgm.clip != clip)
//        {
//            bgm.clip = clip;
//        }

//        bgm.Play();
//    }

//    // 효과음을 설정하는 함수
//    void SetEffect()
//    {
//        foreach (AudioSource a in GameObject.Find("Audio_Effect").GetComponentsInChildren<AudioSource>())
//        {
//            a.volume = DataValue.valueEffectSound();
//        }
//    }

//    // 데이터를 로딩하는 함수
//    public void DataLoading()
//    {
//        new SceneLoader().Generation_Map();

//        new SceneLoader().Generation_Player();
//    }

//    // 게임을 시작하는 함수
//    public void GameStart()
//    {
//        StartCoroutine(GameStartD());
//    }

//    IEnumerator GameStartD()
//    {
//        yield return new WaitForSeconds(2f);

//        gameStart = true;
//    }

//    public void GamePausing()
//    {
//        // 게임진행중이라면
//        if (gameStart == true)
//        {
//            // 일시정지중이아니면
//            if (Time.timeScale == 1)
//            {
//                Time.timeScale = 0;
//                GameObject optionUI = new UIopener().Open_PauseUI();
//                return;
//            }
//            // 일시정지중이면
//            else if (Time.timeScale == 0)
//            {
//                UIcloser.closePause();

//                Time.timeScale = 1;

//                return;
//            }
//        }
//    }

//    public bool Get_GameStatus()
//    {
//        return gameStart;
//    }

//    public void Set_GameStatus(bool value)
//    {
//        gameStart = value;
//    }

//    public GameMode GetGameMode()
//    {
//        return gamemode;
//    }

//    // GameModeDisplayer의 ConvertIntToMode와 return이름 일치시키기
//    public void SetGameMode(string type)
//    {
//        switch(type)
//        {
//            case "normal":
//                gamemode = new ChangeGameMode().Normal();
//                break;

//            case "time":
//                gamemode = new ChangeGameMode().Time();
//                break;

//            case "item":
//                gamemode = new ChangeGameMode().Item();
//                break;

//            case "timeitem":
//                gamemode = new ChangeGameMode().TimeItem();
//                break;
//        }
//    }
//}