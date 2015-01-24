using UnityEngine;
using System.Collections;
public class CollisionEvent : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Debug.Log ("collision");
		if( col.gameObject.tag == "food"){
			Debug.Log("food!");
			col.gameObject.SendMessage("ActiveFalse");
		}
		if( col.gameObject.tag == "goal"){
			Debug.Log("Congratulation!!");
		}
	}
}