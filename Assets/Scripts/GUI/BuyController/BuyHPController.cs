using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BuyHPController : BuyController {

	public GameObject image;
	
	// Use this for initialization
	void Start () {
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < GameConst.HP_COST
			|| SceneManager.GetActiveScene().name == "Home") {
			image.SetActive(true);
		} else {
			image.SetActive(false);
		}
	}

	void Update() {
		if (SceneManager.GetActiveScene().name == "Home") return;

		HPController hpObject = FindObjectOfType<HPController>();
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < GameConst.HP_COST 
		    || Mathf.Abs(hpObject.GetProgress() - 1.0f) < float.Epsilon) {
			image.SetActive(true);
		} else {
			image.SetActive(false);
		}
	}

	#region implemented abstract members of BuyController

	protected override void BuyCompleted () {
		HPController hpObject = FindObjectOfType<HPController>();
		hpObject.IncreaseProcess(40);
		DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -GameConst.HP_COST);
	}

	#endregion
}
