using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements; //Assuming you imported the Advertisements from the "Package Manager"

public class AdsSkippable : MonoBehaviour
{
#if UNITY_IOS
    public string gameId = "Your-Apple-ID";
    public string mySurfacingId = "Interstitial_iOS";
#elif UNITY_ANDROID
    public string gameId = "Your-Google-ID";
    public string mySurfacingId = "Interstitial_Android";
#endif
    public bool testMode = true; //Leave this as True UNTIL you publicly release your game!!!

    public static AdsSkippable instance;
    public bool showAdOnStartGameBool;
    void Start()
    {
        instance = this;
        Advertisement.Initialize(gameId, testMode); //Prepares Everything Immediately
    }
    private void Update()
    {
        if (Advertisement.IsReady() && !showAdOnStartGameBool)
        {
            ShowInterstitialAdOnGameStart();
            showAdOnStartGameBool = true;
            Debug.Log("here");
        }
    }
    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady()) // Check if UnityAds ready before calling Show method:
        {
            Advertisement.Show(mySurfacingId);
            print("You're watching an AD!!!");
        }
        else print("Interstitial ad not ready at the moment! Please try again later!");
    }
    public void ShowInterstitialAdOnGameStart()
    {
        if (Advertisement.IsReady()) // Check if UnityAds ready before calling Show method:
        {
            Advertisement.Show(mySurfacingId);
            print("You're watching an AD!!!");
        }
        else print("Interstitial ad not ready at the moment! Please try again later!");
    }
}