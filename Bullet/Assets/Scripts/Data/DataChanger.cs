using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 데이터의 변경
public class DataChanger
{
    // 테마를 변경하는 함수
    public static void setTheme(string name)
    {
        PlayerPrefs.SetString("NowTheme", name);
        Debug.Log("테마를 변경했다.");
    }

    // 인-게임 재화를 가/감 하는 함수
    public static void modulateMoneyInGame(int n)
    {
        PlayerPrefs.SetInt("Money_InGame", DataValue.valueMoneyInGame() + n);
        Debug.Log("인-게임 재화를 (가/감)산시켰다. (" + n + " 메소)");
    }

    // 현금 재화를 가/감 하는 함수
    public static void modulateMoneyReal(int n)
    {
        PlayerPrefs.SetInt("Money_Real", DataValue.valueMoneyReal() + n);
        Debug.Log("현금 재화를 (가/감)산시켰다. (" + n + " 딸라)");
    }

    // 배경음악 볼륨을 설정하는 함수
    public static void setVolumeBGM(float v)
    {
        float temp = Mathf.Clamp01(v);

        PlayerPrefs.SetFloat("Volume_BGM", temp);
        Debug.Log("배경음악 볼륨을 설정했다. (now : " + temp + ")");
    }

    // 효과음 볼륨을 설정하는 함수
    public static void setVolumeEffect(float v)
    {
        float temp = Mathf.Clamp01(v);

        PlayerPrefs.SetFloat("Volume_Effect", temp);
        Debug.Log("효과음 볼륨을 설정했다. (now : " + temp + ")");
    }

    // 최고점수를 설정하는 함수
    public static void setHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        Debug.Log("최고점수를 갱신했다. (now : " + score + ")");
    }

    // 최고 버틴 시간을 설정하는 함수
    public static void setHighEnduringTime(int time)
    {
        PlayerPrefs.SetInt("HighEnduringTime", time);
        Debug.Log("최고존버시간을 갱신했다. (now : " + time + ")");
    }

    // 조이스틱고정여부를 설정하는 함수
    public static void setJoystickFixed(bool status)
    {
        int s = 0;

        if (status == true) { s = 1; }
        else { s = 0; }
        PlayerPrefs.SetInt("JoystickFixed", s);
    }
}