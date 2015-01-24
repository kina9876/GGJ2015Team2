using UnityEngine;
using System.Collections;

public class GenerateItem : MonoBehaviour {
	public GameObject ItemA;
	//	public GameObject ItemB;
	private GameObject parentA;
	private GameObject parentB;

	void Update () {
	}

	void InstanceItem(Vector3 pos){
		GameObject child = Instantiate(ItemA, pos, transform.rotation) as GameObject;
		GameObject parentA = GameObject.Find("ItemA_Manager");
		child.transform.parent = parentA.transform;
	}
}
