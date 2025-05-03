using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAds : MonoBehaviour
{
    private BannerView banner;
    private InterstitialAd interstitial;

    // 테스트용 앱 아이디
    public string AndroidAppID = "ca-app-pub- 3940256099942544~3347511713";
    public string IphoneAppID = "ca-app-pub-3940256099942544~1458002511";

    // 테스트용 광고 아이디
    public string AndroidBannerAdsID = "ca-app-pub-3940256099942544/6300978111";
    public string IphoneBannerAdsID = "";

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        CreateBanner();
    }

    void CreateBanner()
    {
        // 앱 아이디
        #if UNITY_ANDROID
        string appId = AndroidAppID;
        #elif UNITY_IPHONE
        string appId = IphoneAppID;
        #else
        string appId = "unexpected_platform";
        #endif
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        // 배너광고 아이디
        #if UNITY_ANDROID
        string AdUnitID = AndroidBannerAdsID;
        #else
        string AdUnitID = "unDefind";
        #endif

        //AdSize adsize = new AdSize(320, 50);

        // Create a 320x50 banner at the top of the screen.
        // 일단 스마트배너 사용
        banner = new BannerView(AdUnitID, AdSize.SmartBanner, AdPosition.Top);


        AdRequest request = new AdRequest.Builder().Build();

        banner.LoadAd(request);
    }

    public void BannerShow()
    {
        banner.Show();
    }

    public void BannerHide()
    {
        banner.Hide();
    }
}
