using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeDisplayer : MonoBehaviour
{
    public int gamemode { get; private set; }

    Text message;

    //MainScene main;

    private void Start()
    {
        message = GetComponent<Text>();

        //main = GameObject.FindObjectOfType<MainScene>();

        gamemode = 0;
    }

    void Update()
    {
        ImageSet();
    }

    public void modechange_front()
    {
        int temp = ++gamemode;

        if (temp > 1) { gamemode = 0; ModeSetter(); return; }
        else { gamemode = temp; ModeSetter(); return; }
    }

    public void modechange_back()
    {
        int temp = gamemode - 1;

        if( temp < 0) { gamemode = 1; ModeSetter(); return; }
        else { gamemode = temp; ModeSetter(); return; }
    }

    void ImageSet()
    {
        // 지금 현재는 텍스트로 하지만,
        // 나중에는 이미지로 변환할 예정.
        string mode = ConvertIntToMode();

        message.text = mode;
    }

    void ModeSetter()
    {
        switch(gamemode)
        {
            case 0:
            case 1:
                //main.SetGameMode(ConvertIntToMode());
                break;
        }
    }

    // MainScene의 SetGameMode와 case 이름 일치시키기
    string ConvertIntToMode()
    {
        switch(gamemode)
        {
            case 0:
                return "normal";
            case 1:
                return "time";
            case 2:
                return "item";
            case 3:
                return "timeitem";
        }

        return "normal";
    }
}
