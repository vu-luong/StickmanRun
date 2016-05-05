using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverStateManager : MonoBehaviour {

	public void gotoHomeScene() {
		SceneManager.LoadScene("Home");
	}

	public void gotoPlayScene() {
		string name = HomeStateManager.GetSceneName();
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
}
