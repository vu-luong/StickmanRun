using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Text>().text = DistanceController.runDistance + " M";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
