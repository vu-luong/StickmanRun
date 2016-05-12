using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using admob;

public class GameOverStateManager : MonoBehaviour {

	public void gotoHomeScene() {
		if (!GameConst.IS_TEST) {

			if (Admob.Instance().isInterstitialReady()) 
				Admob.Instance().showInterstitial();

		}
		SceneManager.LoadScene("Home", LoadSceneMode.Single);
		SoundManager.instance.Vibrate();
	}

	public void gotoPlayScene() {
		if (!GameConst.IS_TEST) {
			if (Admob.Instance().isInterstitialReady()) 
				Admob.Instance().showInterstitial();
		}
//		string name = HomeStateManager.GetSceneName();
		SceneManager.LoadScene("Help", LoadSceneMode.Single);
		SoundManager.instance.Vibrate();
	}
}
