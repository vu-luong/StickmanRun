using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopTextController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = DataPref.getNumData(GameConst.NUM_COLLECT_KEY).ToString();
	}
}
