using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeStateManager : MonoBehaviour {
	public GameObject shopCanvas;
	public GameObject achievementCanvas;
	public GameObject settingCanvas;
	private bool moveToStartScene;
	public GameObject loadingText;


	public void Start() {
		moveToStartScene = false;
	}

	public void ShowSetting() {
		settingCanvas.SetActive(true);
		OnPause();
	}

	public void CloseSetting() {
		settingCanvas.SetActive(false);
		OnUnpause();
	}

	public void ShowShop() {
		shopCanvas.SetActive(true);
		OnPause();
	}
	
	public void CloseShop() {
		shopCanvas.SetActive(false);
		OnUnpause();
	}

	public void ShowAchievement() {
		achievementCanvas.SetActive(true);
		OnPause();
	}

	public void CloseAchievement() {
		achievementCanvas.SetActive(false);
		OnUnpause();
	}

	public void MoveToStartScene() {
//		Application.LoadLevel("Play");
		moveToStartScene = true;
	}

	public void goToAchievement() {
		SceneManager.LoadScene("Achievement");
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

		if (moveToStartScene) {
			StartCoroutine(LoadNewScene());
//			loadingText.SetActive(true);
			moveToStartScene = false;
		}

	}

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(0.5f);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = SceneManager.LoadSceneAsync("Play");

//		Debug.Log("Progress" + async.progress);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			print ("%: " + async.progress);
			loadingText.transform.localScale = new Vector3(async.progress, 1);
			yield return null;
		}

	}

	public void OnPause() {
		Time.timeScale = 0;
	}

	public void OnUnpause() {
		Time.timeScale = 1;
	}
}
