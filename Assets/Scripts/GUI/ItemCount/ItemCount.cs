using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class ItemCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetCountToText();
	}
	
	// Update is called once per frame
	void Update () {
		SetCountToText();
	}

	protected abstract int GetItemCount();

	void SetCountToText() {
		int count = GetItemCount();
		GetComponent<Text>().text = "" + count;
	}
}

