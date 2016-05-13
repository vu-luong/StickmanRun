using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using admob;

public class StoryStateManager : MonoBehaviour {

	void Start() {
		SoundManager.instance.PlayMusic(GameConst.STORY_MUSIC);
		if (!GameConst.IS_TEST) {
//			Admob.Instance().removeBanner();
			SoundManager.instance.HideBanner();
		}
	}

	public void GoToHelpScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SoundManager.instance.Vibrate();

		SceneManager.LoadScene("Help", LoadSceneMode.Single);
	}

}
