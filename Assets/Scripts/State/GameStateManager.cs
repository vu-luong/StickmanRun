using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	public GameObject buttonCanvas;
	public GameObject shopCanvas;
	public GameObject image;

	void Update() {
		if (Input.GetKeyDown(KeyCode.P)) {
			OnPause();
		}
	}

	public void OnPause() {
		Time.timeScale = 0;
		buttonCanvas.SetActive(false);
		image.SetActive(true);
	}

	public void OnUnpause() {
		Time.timeScale = 1;
		buttonCanvas.SetActive(true);
		image.SetActive(false);
	}

	public void ShowShop() {
		shopCanvas.SetActive(true);
		OnPause();
	}

	public void CloseShop() {
		shopCanvas.SetActive(false);
		OnUnpause();
	}

	public void GoToGameOver() {
		ItemData.ResetCount();
		Application.LoadLevel("GameOver");
	}

}
