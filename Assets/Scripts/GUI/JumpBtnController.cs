using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpBtnController : MonoBehaviour {

	public void OnJumpDown() {
		GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x*0.8f, 
		                                                       GetComponent<RectTransform>().localScale.y*0.8f, 
		                                                       GetComponent<RectTransform>().localScale.z);
	}
	public void OnJumpUp() {
		GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x/0.8f, 
		                                                       GetComponent<RectTransform>().localScale.y/0.8f, 
		                                                       GetComponent<RectTransform>().localScale.z);
	}

}
