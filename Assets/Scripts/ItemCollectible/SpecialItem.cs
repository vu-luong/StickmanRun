using UnityEngine;
using System.Collections;

public class SpecialItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		string tag = other.gameObject.tag;
		if (tag == "Player") {
			other.GetComponent<PlayerController>().UseSpecialSkill();
			Destroy(gameObject);
		}
	}
}
