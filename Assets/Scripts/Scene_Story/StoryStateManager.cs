using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryStateManager : MonoBehaviour {

	public void GoToHelpScene() {
		SoundManager.instance.PlaySingleByName(GameConst.BUTTON_CLICK_AUDIO);
		SceneManager.LoadScene("Help", LoadSceneMode.Single);
	}

}
