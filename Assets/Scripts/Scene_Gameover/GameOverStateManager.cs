using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverStateManager : MonoBehaviour {

	public void gotoHomeScene() {
		SceneManager.LoadScene("Home", LoadSceneMode.Single);
	}

	public void gotoPlayScene() {
		string name = HomeStateManager.GetSceneName();
		SceneManager.LoadScene("Story", LoadSceneMode.Single);
	}
}
