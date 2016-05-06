using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestDistance : MonoBehaviour {

	int count, maxCount, unit;
	Text tex;

	// Use this for initialization
	void Start () {
		int runResult = DistanceController.runDistance;

		int bestDistance = DataPref.getNumData(GameConst.BEST_DISTANCE_KEY);

		if (bestDistance < runResult) {
			bestDistance = runResult;
			DataPref.setNumData(GameConst.BEST_DISTANCE_KEY, bestDistance);
		}

		count = 0;
		tex = GetComponent<Text>();

		tex.text = count + " M";
		maxCount = bestDistance;
		unit = maxCount / GameConst.TIME_INC_ANIM;
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= maxCount) return;

		count += unit;
		if (count >= maxCount) {
			count = maxCount;
		}

		tex.text = count + " M";
	}
}
