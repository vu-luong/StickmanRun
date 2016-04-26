using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AchievementStateManager : MonoBehaviour {

	public void goToHome() {
		SceneManager.LoadScene("Home");
	}

}
