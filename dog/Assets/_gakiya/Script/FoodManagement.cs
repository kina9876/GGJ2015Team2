using UnityEngine;
using System.Collections;

public class FoodManagement : MonoBehaviour {
	public GameObject ButtonA;
	public GameObject ButtonB;
	public bool foodFlg = true; /* true == food_A
								  false == food_B */

	void Start () {
	
	}

	void Update () {
		if( foodFlg == true ){
			ButtonA.SetActive(true);
			ButtonB.SetActive(false);
		} else {
			ButtonA.SetActive(false);
			ButtonB.SetActive(true);
		}
	}

	void flgChange(){
		if( foodFlg == true ){
			foodFlg = false;
		} else {
			foodFlg = true;
		}
	}
}
