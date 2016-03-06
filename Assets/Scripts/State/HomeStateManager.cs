using UnityEngine;
using System.Collections;

public class HomeStateManager : MonoBehaviour {
	public GameObject shopCanvas;

	public void ShowShop() {
		shopCanvas.SetActive(true);
	}
	
	public void CloseShop() {
		shopCanvas.SetActive(false);
	}

	public void MoveToStartScene() {
		Application.LoadLevel("Play");
	}

	public void goToAchievement() {
		Application.LoadLevel("Achievement");
	}

	public void ExitGame() {
		Application.Quit();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.U)) {
			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -30);
		}
		
		if (Input.GetKeyDown(KeyCode.I)) {
			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, 30);
		}
	}
}
