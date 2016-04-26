using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveMeController : MonoBehaviour {

	public GameObject player;
	public GameObject gameOverCanvas;

	// Use this for initialization
	void Start () {
	}



	// Update is called once per frame
	void Update() {
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < ItemData.NumToSave) {
			GetComponent<Image>().color = Color.gray;
			GetComponent<Button>().enabled = false;
		} else {
			GetComponent<Image>().color = Color.white;
			GetComponent<Button>().enabled = true;
		}

	}


	public void OnClick () {
//		Debug.Log("Reborn");
//		ItemData.AddUp(1);
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < ItemData.NumToSave) return;

		player.GetComponent<PlayerController>().Save();
		gameOverCanvas.SetActive(false);
		DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -ItemData.NumToSave);
		ItemData.AddNumToSave(ItemData.NumToSave);
	}
}
