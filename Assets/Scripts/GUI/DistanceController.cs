using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour {
	public static int runDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateDistance(float dis) {
		this.GetComponent<Text>().text = (int)dis + "";
		runDistance = (int) dis;
	}

}
