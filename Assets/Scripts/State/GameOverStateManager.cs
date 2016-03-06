using UnityEngine;
using System.Collections;

public class GameOverStateManager : MonoBehaviour {

	public void gotoHomeScene() {
		Application.LoadLevel("Home");
	}

	public void gotoPlayScene() {
		Application.LoadLevel("Play");
	}
}
