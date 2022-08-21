﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Admanager : MonoBehaviour
{

    public static Admanager instance;

    //private string appID = "ca-app-pub-3940256099942544~3347511713";

    private BannerView bannerView;
    private string bannerID = "ca-app-pub-2130174745533832/3767447904";

    private InterstitialAd fullScreenAd;
    private string fullScreenAdID = "ca-app-pub-2130174745533832/5634546426";




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        RequestFullScreenAd();
    }


    public void RequestBanner()
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);

        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void RequestFullScreenAd()
    {
        fullScreenAd = new InterstitialAd(fullScreenAdID);

        AdRequest request = new AdRequest.Builder().Build();

        fullScreenAd.LoadAd(request);

    }

    public void ShowFullScreenAd()
    {
        if (fullScreenAd.IsLoaded())
        {
            fullScreenAd.Show();
        }
        else
        {
            Debug.Log("Full screen ad not loaded");
        }
    }
}
