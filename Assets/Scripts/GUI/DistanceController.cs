﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour {
	public static int runDistance;

	public void updateDistance(float dis) {
		this.GetComponent<Text>().text = (int)dis + "";
		runDistance = (int) dis;
	}

}
