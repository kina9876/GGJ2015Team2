using UnityEngine;
using System.Collections;
public class CollisionEvent : MonoBehaviour {
	private GameObject clearManager;

	void Start(){
		clearManager = GameObject.Find ("ClearManager");
	}

	void OnCollisionEnter(Collision col){
		Debug.Log ("collision");
		if( col.gameObject.tag == "food"){
			Debug.Log("food!");
			col.gameObject.SendMessage("ActiveFalse");
		}
	}
	void OnTriggerEnter(Collider col){
		if( col.gameObject.tag == "goal"){
			Debug.Log("Congratulation!!");
			iTween.Stop ();

			// Animation
			// col.gameObject.Animation

			clearManager.SendMessage("Clear");
		}
	}
}