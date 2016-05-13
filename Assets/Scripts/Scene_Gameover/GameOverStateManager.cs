using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using admob;

public class GameOverStateManager : MonoBehaviour {

	void Start(){
		SoundManager.instance.PlaySingleByNameLoop(GameConst.COUNT_AUDIO);
	}

	void StopSound() {
	}

	public void gotoHomeScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		if (!GameConst.IS_TEST) {

//			if (Admob.Instance().isInterstitialReady()) 
//				Admob.Instance().showInterstitial();

			SoundManager.instance.ShowFullAd();
		}
		SceneManager.LoadScene("Home", LoadSceneMode.Single);
		SoundManager.instance.Vibrate();
	}

	public void gotoPlayScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		if (!GameConst.IS_TEST) {
//			if (Admob.Instance().isInterstitialReady()) 
//				Admob.Instance().showInterstitial();
			SoundManager.instance.ShowFullAd();
		}
//		string name = HomeStateManager.GetSceneName();
		SceneManager.LoadScene("Help", LoadSceneMode.Single);
		SoundManager.instance.Vibrate();
	}
}
