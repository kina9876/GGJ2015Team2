using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {
	Animator animator;

	void Start(){
		animator = this.GetComponent<Animator> ();
	}
}
