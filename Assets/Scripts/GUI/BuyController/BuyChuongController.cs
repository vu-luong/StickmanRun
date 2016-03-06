﻿using UnityEngine;
using System.Collections;

public class BuyChuongController : BuyController {

	public GameObject image;
	
	// Use this for initialization
	void Start () {
		//		image.SetActive(true);
		
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < GameConst.CHUONG_COST) {
			image.SetActive(true);
		} else {
			image.SetActive(false);
		}
	}

	void Update () {
		if (DataPref.getNumData(GameConst.NUM_COLLECT_KEY) < GameConst.CHUONG_COST) {
			image.SetActive(true);
		} else {
			image.SetActive(false);
		}
	}

	#region implemented abstract members of BuyController

	protected override void BuyCompleted () {
		ItemData.AddChuong(1);
		DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -GameConst.CHUONG_COST);
	}

	#endregion
}