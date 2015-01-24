using UnityEngine;
using System.Collections;

public class ActiveChange : MonoBehaviour {

	void ActiveFalse(){
		gameObject.SetActive(false);
		rigidbody.velocity = Vector3.zero;
	}
}
