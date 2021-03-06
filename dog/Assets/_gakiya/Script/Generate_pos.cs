﻿using UnityEngine;
using System.Collections;

public class Generate_pos : MonoBehaviour {
	private Vector3 clickPosition;

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			/* position check */
			clickPosition = Input.mousePosition;
			clickPosition.z = 10;
			Vector3 mousePos = camera.ScreenToWorldPoint(clickPosition);
			int posX = (int)Mathf.Round(mousePos.x);
			int posZ = (int)Mathf.Round(mousePos.z);
			Vector3 instancePos = new Vector3(posX, 2, posZ);
			if( Mathf.Abs(posX) < 2.5 && Mathf.Abs(posZ) < 2.5){
				/* placing check */
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray,out hit)){
					if(hit.collider.gameObject.tag == "ground"){
						/* Let's generate a meat */
						GameObject.Find("GameController").SendMessage("InstanceItem", instancePos);
					} else {
						Debug.Log ("not ground" );
					}
				} else {
					Debug.Log ("didn't hit a ray");
				}
			} else {
				Debug.Log("Out of field" + "\n" + 
				          "x = "  + posX + " / " + "z = " + posZ);
			}
		}

		/* debug */
//		clickPosition = Input.mousePosition;
//		clickPosition.z = 10;
//		Debug.Log(camera.ScreenToWorldPoint(clickPosition));
	}
}
