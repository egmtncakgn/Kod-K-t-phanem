using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerReklam : MonoBehaviour
{
    private BannerView bannerView;

    public string id = "";
    public bool test = true;
    void Start()
    {
        if (test)
            id = "ca-app-pub-3940256099942544/6300978111";

        bannerView = new BannerView(id, AdSize.Banner, AdPosition.Bottom);

        AdRequest reklamiste = new AdRequest.Builder().Build();

        bannerView.LoadAd(reklamiste);
        bannerView.Show();
    }
}
