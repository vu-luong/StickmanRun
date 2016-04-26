using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverStateManager : MonoBehaviour {

	public void gotoHomeScene() {
		SceneManager.LoadScene("Home");
	}

	public void gotoPlayScene() {
		SceneManager.LoadScene("Play");
	}
}
