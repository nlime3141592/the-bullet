using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataValue
{
    // 플레이어가 선택한 테마
    public static string valueTheme()
    {
        return PlayerPrefs.GetString("NowTheme");
    }

    // 플레이어가 가진 인-게임 재화
    public static int valueMoneyInGame()
    {
        return PlayerPrefs.GetInt("Money_InGame");
    }

    // 플레이어가 가진 현금 재화
    public static int valueMoneyReal()
    {
        return PlayerPrefs.GetInt("Money_Real");
    }

    // 플레이어의 최고 점수
    public static int valueHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    // 최고 버틴 시간
    public static int valueHighEnduringTime()
    {
        return PlayerPrefs.GetInt("HighEnduringTime");
    }

    // 배경음악 볼륨
    public static float valueBGM()
    {
        return PlayerPrefs.GetFloat("Volume_BGM");
    }

    // 효과음 볼륨
    public static float valueEffectSound()
    {
        return PlayerPrefs.GetFloat("Volume_Effect");
    }

    // 조이스틱고정여부
    public static bool valueJoystickFixed()
    {
        return PlayerPrefs.GetInt("JoystickFixed") == 1 ? true : false;
    }
}