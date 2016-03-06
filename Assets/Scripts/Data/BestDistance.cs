using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int runResult = DistanceController.runDistance;

		int bestDistance = DataPref.getNumData(GameConst.BEST_DISTANCE_KEY);

		if (bestDistance < runResult) {
			bestDistance = runResult;
			DataPref.setNumData(GameConst.BEST_DISTANCE_KEY, bestDistance);
		}

		GetComponent<Text>().text = bestDistance + " M";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
