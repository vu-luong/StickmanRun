using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeStateManager : MonoBehaviour {
	public GameObject shopCanvas;
	public GameObject achievementCanvas;
	public GameObject settingCanvas;
	public GameObject loadingText;

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
		int a = Random.Range(0, 5);

		return "Play" + a;

	}
}
