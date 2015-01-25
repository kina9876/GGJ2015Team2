using UnityEngine;
using System.Collections;

public class ClearPerformance : MonoBehaviour {
	public GameObject ClearPlane;
	private bool clearFlg;

	void Start(){
		clearFlg = false;
		ClearPlane.SetActive (false);
	}

	void Update(){
		if (clearFlg == true) {
			ClearPlane.SetActive (true);
		}
	}

	void Clear(){
		clearFlg = true;
	}

	void NextStage(){
	Debug.Log ("Go → NextStage");
	//	Application.LoadLevel (Application.loadedLevel +1);
	}

	void Retry(){
		Debug.Log ("Try Again for Now Stage");
	//	Application.LoadLevel (Application.loadedLevel);
	}

	void GoToTitle(){
		Debug.Log ("Go → Title");
	//	Application.LoadLevel (0);
	}
}
