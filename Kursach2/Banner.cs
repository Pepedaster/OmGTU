//using UnityEngine;
//using UnityEngine.Advertisements;

//public class Banner : MonoBehaviour
//{
//    [SerializeField] BannerPosition bannerPosition;

//    [SerializeField] string androidAdID = "Banner_Android";
//    [SerializeField] string iOSAdID = "Banner_iOS";
//    private string adID;

//    private void Awake()
//    {
//        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;
//    }

//    private void Start()
//    {
//        Advertisement.Banner.SetPosition(bannerPosition);
//    }

//    public void ShowAd()
//    {
//        BannerLoadOptions optionsLoad = new BannerLoadOptions { loadCallback = OnBannerLoaded, errorCallback = OnBannerError };
//        Advertisement.Banner.Load(adID, optionsLoad);

//        BannerOptions optionsShow = new BannerOptions { clickCallback = OnBannerClicked, hideCallback = OnBannerHidden, showCallback = OnBannerShow };
//        Advertisement.Banner.Show(adID, optionsShow);
//    }

//    private void OnBannerLoaded()
//    {
//        Debug.Log("Баннер загружен");
//    }

//    private void OnBannerError(string message)
//    {
//        Debug.Log($"Ошибка загрузки баннера: {message}");
//    }

//    private void OnBannerClicked()
//    {
//        Debug.Log("Баннер был кликнут");
//    }

//    private void OnBannerHidden()
//    {
//        Debug.Log("Баннер был скрыт");
//    }

//    private void OnBannerShow()
//    {
//        Debug.Log("Баннер был показан");
//    }
//}