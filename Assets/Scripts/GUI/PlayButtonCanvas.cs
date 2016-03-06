using UnityEngine;
using System.Collections;

public class PlayButtonCanvas : MonoBehaviour {
		
	public GameObject chuongCanvas;
	public GameObject dragonCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
		if (ItemData.ChuongCount <= 0) {
			chuongCanvas.SetActive(false);
		} else chuongCanvas.SetActive(true);

		if (ItemData.DragonCount <= 0) dragonCanvas.SetActive(false);
		else dragonCanvas.SetActive(true);

	}
}
