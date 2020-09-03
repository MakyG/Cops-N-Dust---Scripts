using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdScript : MonoBehaviour
{
    string GP_ID = "3550534";
    public bool testMode = false;
    void Start()
    {
        Advertisement.Initialize(GP_ID, testMode);
    }

    public static void showAd()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }
    public void showAdRewarded()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
        }
    }
}
