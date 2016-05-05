using UnityEngine;
using System.Collections;

public class HPItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		string tag = other.gameObject.tag;
		if (tag == "Player") {
			HPController hpObject = FindObjectOfType<HPController>();
			hpObject.IncreaseProcess(40);
			Destroy(gameObject);
		}
	}
}
