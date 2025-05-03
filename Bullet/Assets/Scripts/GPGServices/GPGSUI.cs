using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public static class GPGSUI
{
    // GPGS 시스템을 사용하기 위해 실행되어야 하는 함수
    // 앱 시작하는 순간 바로 실행시킨다.
    public static void EnableGPGS()
    {
        //PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    public static void OpenLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public static void OpenAchivementBoard()
    {
        Social.ShowAchievementsUI();
    }

    // 자동로그인
    public static void OpenAutoLogin()
    {
        // 만약 로그인이 되어있지 않다면
        if (!Social.localUser.authenticated)
        {
            // 유저 정보 등록 시도
            Social.localUser.Authenticate(AuthenticatingCheck);
        }
    }

    // 수동로그인
    public static void OpenPassiveLogin()
    {
        // 로그인이 되어있지 않다면
        if (!Social.localUser.authenticated)
        {
            // 유저 정보 등록 시도
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    // 수동로그인 성공했을 경우 실행
                }
                else
                {
                    // 수동로그인 실패했을 경우 실행
                }
            });
        }
    }

    // 로그아웃
    public static void LogOut()
    {
        // 로그아웃 하는 함수
        //((PlayGamesPlatform)Social.Active).SignOut();
    }

    // 자동로그인시 필요한 콜백 함수
    // 로그인 성공 여부에 따라 실행될 함수가 결정된다.
    static void AuthenticatingCheck(bool success)
    {
        // 자동로그인에 성공했다면
        if(success)
        {
            // 실행
        }
        // 실패했다면
        else
        {
            // 실행
        }
    }
}
