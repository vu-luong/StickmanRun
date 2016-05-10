using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

	public GameObject buttonCanvas;
	public GameObject shopCanvas;
	public GameObject image;
	public GameObject completeCanvas;
	public GameObject buyCanvas;

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
		completeCanvas.SetActive(false);
		buyCanvas.SetActive(true);

		OnUnpause();
	}

	public void GoToGameOver() {
		ItemData.ResetCount();
		SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
	}

}
