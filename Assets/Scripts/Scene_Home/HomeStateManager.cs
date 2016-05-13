using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
//using admob;

public class HomeStateManager : MonoBehaviour {
	public GameObject shopCanvas;
	public GameObject achievementCanvas;
	public GameObject settingCanvas;
	public GameObject loadingText;
	public GameObject completeCanvas;
	public GameObject buyCanvas;

	private static int gameCount;

	void Awake() {
	}

	void Start() {
		SoundManager.instance.PlayMusic(GameConst.HOME_MUSIC);
		if (!GameConst.IS_TEST) {
			SoundManager.instance.ShowBanner();
//			Admob.Instance().interstitialEventHandler += onInterstitialEvent;
//			Admob.Instance().bannerEventHandler += onBannerEvent;
//			Admob.Instance().showBannerRelative(new AdSize(310, 45), AdPosition.BOTTOM_CENTER, 0);
		}

	}

	public void ShowSetting() {

		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		settingCanvas.SetActive(true);
		OnPause();
	}

	public void CloseSetting() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		settingCanvas.SetActive(false);
		OnUnpause();
	}

	public void ShowShop() {

		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();
		shopCanvas.SetActive(true);
		OnPause();
	}
	
	public void CloseShop() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		shopCanvas.SetActive(false);
		completeCanvas.SetActive(false);
		buyCanvas.SetActive(true);
		OnUnpause();
	}

	public void ShowAchievement() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		achievementCanvas.SetActive(true);
		OnPause();
	}

	public void CloseAchievement() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		achievementCanvas.SetActive(false);
		OnUnpause();
	}

	public void GoToHelpScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		SceneManager.LoadScene("Help", LoadSceneMode.Single);
	}

	public void GoToStoryScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		SceneManager.LoadScene("Story", LoadSceneMode.Single);
	}

	public void ExitGame() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		Application.Quit();
	}

//	void Update() {
//		if (Input.GetKeyDown(KeyCode.U)) {
//			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -30);
//		}
//		
//		if (Input.GetKeyDown(KeyCode.I)) {
//			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, 30);
//		}
//	}

	public void OnPause() {
		Time.timeScale = 0;
	}

	public void OnUnpause() {
		Time.timeScale = 1;
	}

	public static string GetSceneName() {
		int a = gameCount;
		gameCount += 1;
		if (gameCount == 4) gameCount = 0;
		return "Play" + a;
	}

	private const string FACEBOOK_APP_ID = "796747923679740";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

	public void Share() {
		string appStoreLink = "https://play.google.com/store/apps/details?id=com.zitga.TowerDefense";
		string facebookshare = "https://www.facebook.com/sharer/sharer.php?u=" + Uri.EscapeUriString(appStoreLink);
		SoundManager.instance.Vibrate();
		Application.OpenURL(facebookshare);

	}


//	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
//	{
//		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
//			"&link=" + WWW.EscapeURL(linkParameter) +
//			"&name=" + WWW.EscapeURL(nameParameter) +
//			"&caption=" + WWW.EscapeURL(captionParameter) + 
//			"&description=" + WWW.EscapeURL(descriptionParameter) + 
//			"&picture=" + WWW.EscapeURL(pictureParameter) + 
//			"&redirect_uri=" + WWW.EscapeURL(redirectParameter));
//	}


	void onInterstitialEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
//		if (eventName == AdmobEvent.onAdClosed)
//		{
//			Admob.Instance().loadInterstitial();
//		}
	}

	void onBannerEvent(string eventName, string msg) {
//		Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
//		if (eventName == AdmobEvent.onAdLoaded)
//		{
//			Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
//		}
	}

	public void OnShowLeaderBoardClick() {
		if (!GameConst.IS_TEST) {
			int bestDistance = DataPref.getNumData(GameConst.BEST_DISTANCE_KEY);
			Social.ReportScore(bestDistance, "CgkI3tfW-NMLEAIQBQ", (bool success) => {
				// handle success or failure
				Debug.Log("status post score: " + success);
				SoundManager.instance.ShowLeaderBoard();
			});
		}

	}
}
