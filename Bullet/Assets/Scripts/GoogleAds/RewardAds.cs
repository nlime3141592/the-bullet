using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class RewardAds : MonoBehaviour
{
    private RewardedAd rewardAd;

    private WatchedAds watched;

    public string AndroidRewardAdsID = "ca-app-pub-3940256099942544/5224354917";
    public string IphoneRewardAdsID = "ca-app-pub-3940256099942544/1712485313";

    private void Start()
    {
        CreateRewardAd();
    }

    // 광고를 로딩하는 함수
    void CreateRewardAd()
    {
        // 보상형광고 아이디
        #if UNITY_ANDROID
        string adUnitID = AndroidRewardAdsID;
        #elif UNITY_IPHONE
        string adUnitID = IphoneRewardAdsID;
        #endif

        this.rewardAd = new RewardedAd(adUnitID);
        watched = new WatchedAds();

        // 광고가 성공적으로 호출되었을 때 실행
        this.rewardAd.OnAdLoaded += HandleRewardedAdLoaded;

        // 광고 호출에 실패했을 때
        this.rewardAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        
        // 광고를 보여줄 때
        this.rewardAd.OnAdOpening += HandleRewardedAdOpening;
        
        // 광고 보여주기를 실패했을 때
        this.rewardAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;

        // 플레이어가 광고를 완료하고 보상을 받아야 할 때
        // 제일 중요함 !!!!!
        this.rewardAd.OnUserEarnedReward += HandleUserEarnedReward;
        
        // 광고를 닫을 때
        // 광고를 닫을 때 새로운 객체를 생성해버리자.
        this.rewardAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        this.rewardAd.LoadAd(request);
    }

    // 실제 광고를 보여주는 함수
    public void ShowAds()
    {
        rewardAd.Show();
    }

    // 광고가 성공적으로 호출되었을 때 실행
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    // 광고 호출에 실패했을 때
    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    // 광고를 보여줄 때
    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Time.timeScale = 0;
        GameObject.FindObjectOfType<SoundControl>().RewardAdsOpened = 0;
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    // 광고 보여주기를 실패했을 때
    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    // 광고를 닫을 때
    // 광고를 닫을 때 새로운 객체를 생성해버리자.
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Time.timeScale = 1;
        GameObject.FindObjectOfType<SoundControl>().RewardAdsOpened = 1;
        MonoBehaviour.print("HandleRewardedAdClosed event received");

        // 이어하기
        StartCoroutine(Continue());

        // 광고 로딩
        CreateRewardAd();
    }

    // 플레이어가 광고를 완료하고 보상을 받아야 할 때
    // 제일 중요함 !!!!!
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        // 시청 완료!
        watched.watched = true;
    }

    // 이어하기
    IEnumerator Continue()
    {
        // 기다리기 (1)
        yield return new WaitUntil(() => watched.watched == true);

        // 이어하기 UI 띄우기
        ContinueUIShow();
    }

    void ContinueUIShow()
    {
        GameObject ui = new UIopener().Open_ContinueUI();
    }
}

class WatchedAds
{
    public bool watched = false;
}
