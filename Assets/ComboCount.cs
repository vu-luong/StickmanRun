using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboCount : MonoBehaviour {

	public static int comboNum;

	public static int ComboNum {
		get {
			return comboNum;
		}
		set {
			comboNum = value;
		}
	}

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = "" + comboNum;
	}

	void Update() {
		GetComponent<Text>().text = "" + comboNum;
	}
	
}
