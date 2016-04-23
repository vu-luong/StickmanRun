using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverStateManager : MonoBehaviour {

	public void gotoHomeScene() {
		Application.LoadLevel("Home");
	}

	public void gotoPlayScene() {
		SceneManager.LoadScene("Play");
	}
}
