using UnityEngine;
using System.Collections;

public class HPController : ProgressBar {

	#region implemented abstract members of ProgressBar
	
	protected override void InitProcessAndUnit () {
		progress = 1f;
		unit = 0.01f;
	}
	
	#endregion
	
	// Update is called once per frame
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			DecreaseProcess(20);
		}
	}
}
