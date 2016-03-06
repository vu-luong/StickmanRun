using UnityEngine;
using System.Collections;

public class BuyHPController : BuyController {

	public GameObject image;
	
	// Use this for initialization
	void Start () {
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < GameConst.HP_COST
		    || Application.loadedLevelName == "Home") {
			image.SetActive(true);
		} else {
			image.SetActive(false);
		}
	}

	void Update() {
		if (Application.loadedLevelName == "Home") return;

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
