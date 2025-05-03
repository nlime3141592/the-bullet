using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 데이터의 초기화
public static class ClearData
{
    // 모든 데이터를 초기화하는 함수
    public static void ResetDatas()
    {
        // 플레이어가 직접 설정한 옵션 ...(1)
        PlayerPrefs.SetString("NowTheme", "mountain");

        // 재화
        PlayerPrefs.SetInt("Money_InGame", 0);
        PlayerPrefs.SetInt("Money_Real", 0);

        // 점수
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("HighEnduringTime", 0);
        // 점수 단위를 계속 추가할수록
        // DataValue와 DataChanger를 만들어줘야함.

        // 음악
        PlayerPrefs.SetFloat("Volume_BGM", 0.3f);
        PlayerPrefs.SetFloat("Volume_Effect", 0.3f);

        // 상점 물품 구매 여부
        // 1 = 가지고 있다, 0 = 가지고있지않다
        // _뒤의 이름은 (1)의 테마이름과 같게 설정한다.
        PlayerPrefs.SetInt("Theme_mountain", 1);
        PlayerPrefs.SetInt("Theme_rainbow", 1);
        PlayerPrefs.SetInt("Theme_sea", 1);
        PlayerPrefs.SetInt("Theme_snowmountain", 1);
        PlayerPrefs.SetInt("Theme_volcano", 1);

        // 광고 제거 상품 구매 여부
        PlayerPrefs.SetInt("Has_NoAds", 0);

        // 조이스틱 고정 여부
        // 1 = 고정, 0 = 고정안됨
        PlayerPrefs.SetInt("JoystickFixed", 0);

        Debug.Log("데이터 초기화!!");
    }

    // 앱 업데이트 확인
    public static void UpdateCheck()
    {
        // 2019_Bullet_1.2.apk
        string version = "1.2";

        if(PlayerPrefs.GetString("Update") == null)
        {
            Debug.Log("버전 Up에 따른 데이터 초기화");
            PlayerPrefs.SetString("Update", version);
            ResetDatas();
            return;
        }

        if (PlayerPrefs.GetString("Update") != version)
        {
            Debug.Log("버전 Up에 따른 데이터 초기화");
            PlayerPrefs.SetString("Update", version);
            ResetDatas();
        }
    }
}