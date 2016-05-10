using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class HomeStateManager : MonoBehaviour {
	public GameObject shopCanvas;
	public GameObject achievementCanvas;
	public GameObject settingCanvas;
	public GameObject loadingText;
	public GameObject completeCanvas;
	public GameObject buyCanvas;

	public void ShowSetting() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);

		settingCanvas.SetActive(true);
		OnPause();
	}

	public void CloseSetting() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		settingCanvas.SetActive(false);
		OnUnpause();
	}

	public void ShowShop() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		shopCanvas.SetActive(true);
		OnPause();
	}
	
	public void CloseShop() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		shopCanvas.SetActive(false);
		completeCanvas.SetActive(false);
		buyCanvas.SetActive(true);
		OnUnpause();
	}

	public void ShowAchievement() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		achievementCanvas.SetActive(true);
		OnPause();
	}

	public void CloseAchievement() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		achievementCanvas.SetActive(false);
		OnUnpause();
	}

	public void GoToHelpScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SceneManager.LoadScene("Help", LoadSceneMode.Single);
	}

	public void GoToStoryScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SceneManager.LoadScene("Story", LoadSceneMode.Single);
	}

	public void ExitGame() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		Application.Quit();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.U)) {
			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -30);
		}
		
		if (Input.GetKeyDown(KeyCode.I)) {
			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, 30);
		}
	}

	public void OnPause() {
		Time.timeScale = 0;
	}

	public void OnUnpause() {
		Time.timeScale = 1;
	}

	public static string GetSceneName() {
		int a = UnityEngine.Random.Range(0, 5);

		return "Play" + a;
	}

	private const string FACEBOOK_APP_ID = "796747923679740";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

	public void Share() {
		string appStoreLink = "https://play.google.com/store/apps/details?id=com.zitga.TowerDefense";
		string facebookshare = "https://www.facebook.com/sharer/sharer.php?u=" + Uri.EscapeUriString(appStoreLink);
		Application.OpenURL(facebookshare);
//		ShareToFacebook(appStoreLink, "tower defense", "blabla", "blabla", null, null);
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
}
