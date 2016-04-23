using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunResult : MonoBehaviour {
		
	int count, maxCount, unit;

	// Use this for initialization
	void Start () {
		count = 0;
		this.GetComponent<Text>().text = count + " M";
		maxCount = DistanceController.runDistance;
		unit = maxCount / GameConst.TIME_INC_ANIM;
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= maxCount) return;

		count += unit;
		if (count >= maxCount) {
			count = maxCount;
		}

		this.GetComponent<Text>().text = count + " M";

	}
}
