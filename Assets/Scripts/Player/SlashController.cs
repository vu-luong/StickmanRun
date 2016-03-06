using UnityEngine;
using System.Collections;

public class SlashController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("FinishSlash", 0.1f);
	}

	void FinishSlash() {
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {


	}

}
