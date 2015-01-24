﻿using UnityEngine;
using System.Collections;

public class GenerateItem : MonoBehaviour {
	public GameObject ItemA;
	public GameObject ItemB;
	private GameObject parentA;
	private GameObject parentB;

	private GameObject childA;
	private GameObject childB;


	void Start(){
		childA = Instantiate(ItemA, new Vector3(0, -1, 0 ), transform.rotation) as GameObject;
		childB = Instantiate(ItemB, new Vector3(0, -1, 0 ), transform.rotation) as GameObject;
	}

	void InstanceItem(Vector3 pos){
		GameObject foodManager = GameObject.Find ("FoodManager");
		if( foodManager.GetComponent<FoodManagement>().foodFlg == true ){
			childA.SetActive(true);
			childA.transform.position = pos;
			childA.name = ("Item" + "A" + pos.x + " , " + pos.z);
		} else {
			childB.SetActive(true);
			childB.transform.position = pos;
			childB.name = ("Item" + "B" + pos.x + " , " + pos.z);
		}
	}
}