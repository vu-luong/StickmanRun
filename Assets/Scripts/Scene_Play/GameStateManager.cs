using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using admob;

public class GameStateManager : MonoBehaviour {

	public GameObject buttonCanvas;
	public GameObject shopCanvas;
	public GameObject image;
	public GameObject completeCanvas;
	public GameObject buyCanvas;

	void Start() {
		SoundManager.instance.PlayMusic(GameConst.PLAY_MUSIC);
	}

	public void OnPause() {
		if (!GameConst.IS_TEST) {
			Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
		}

		Time.timeScale = 0;
		buttonCanvas.SetActive(false);
		image.SetActive(true);
	}

	public void OnUnpause() {
		if (!GameConst.IS_TEST) { 
			Admob.Instance().removeBanner();
		}

		Time.timeScale = 1;
		buttonCanvas.SetActive(true);
		image.SetActive(false);
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

	public void GoToGameOver() {
		ItemData.ResetCount();
		SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
	}

	public void GoToVictory() {
		ItemData.ResetCount();
		SceneManager.LoadScene("Victory", LoadSceneMode.Single);
	}

}
