using UnityEngine;
using System.Collections;
public class CollisionEvent : MonoBehaviour {
	private GameObject clearManager;

	void Start(){
		clearManager = GameObject.Find ("ClearManager");
		Time.timeScale = 1;
	}
	
	void OnTriggerEnter(Collider col){
		Debug.Log ("collision  " + col.tag);

		if( col.gameObject.tag == "food"){
			Debug.Log("food!");
			col.gameObject.SendMessage("ActiveFalse");
		}
		if( col.gameObject.tag == "Player"){
			Debug.Log("Congratulation!!");
			iTween.Stop ();
			Time.timeScale = 0;
			// Animation
			// col.gameObject.Animation

			clearManager.SendMessage("Clear");
		}

		if (col.gameObject.tag == Const.WALL_TAG) {
			//iTween.Stop();
			transform.SendMessage("wallTouch");
		}

	}
}