using UnityEngine;
using System.Collections;

public class BuyMagnetController : BuyController {

	public GameObject image;
	
	// Use this for initialization
	void Start () {
		//		image.SetActive(true);
		
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < GameConst.MAGNET_COST) {
			image.SetActive(true);
		} else {
			image.SetActive(false);
		}
	}

	void Update () {
		//		image.SetActive(true);
		
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < GameConst.MAGNET_COST) {
			image.SetActive(true);
		} else {
			image.SetActive(false);
		}
	}

	#region implemented abstract members of BuyController

	protected override void BuyCompleted () {
		ItemData.AddTimeMagnet(15.0f);
		DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -GameConst.MAGNET_COST);
	}

	#endregion
}
