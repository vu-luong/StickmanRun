using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = DataPref.getNumData(GameConst.NUM_COLLECT_KEY).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (enabled) {
			GetComponent<Text>().text = DataPref.getNumData(GameConst.NUM_COLLECT_KEY).ToString();
		}
	}
}
