using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButtonCanvas : MonoBehaviour {
		
	public GameObject chuongButton;
	public GameObject dragonButton;
	public GameObject surikenButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
		if (ItemData.ChuongCount <= 0) {
//			chuongCanvas.SetActive(false);
			chuongButton.GetComponent<Image>().color = new Color32(92, 92, 92, 255);
		} else {
			chuongButton.GetComponent<Image>().color = Color.white;
//			chuongCanvas.SetActive(true);
		}

		if (ItemData.DragonCount <= 0) {
//			dragonCanvas.SetActive(false);	
			dragonButton.GetComponent<Image>().color = new Color32(92, 92, 92, 255);
		} else {
//			dragonCanvas.SetActive(true);	
			dragonButton.GetComponent<Image>().color = Color.white;
		}

		if (ItemData.SurikenCount <= 0) {
			//			chuongCanvas.SetActive(false);
			surikenButton.GetComponent<Image>().color = new Color32(92, 92, 92, 255);
		} else {
			surikenButton.GetComponent<Image>().color = Color.white;
			//			chuongCanvas.SetActive(true);
		}

	}
}
