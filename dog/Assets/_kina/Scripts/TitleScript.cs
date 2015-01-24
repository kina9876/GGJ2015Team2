using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	public GameObject dog;
	public float rotationSpeed;
	public GameObject floor;
	public int tileCount;
	public Vector3 startPosition;
	public Vector3 floorScale;


	// Use this for initialization
	void Start () {
		GameObject stage = GameObject.Find("Stage");
		/*
		for (int i = 0; i < tileCount; i++) {
			for (int x = 0; x < tileCount; x++) {
				GameObject  tile = Instantiate(floor,startPosition,Quaternion.identity) as GameObject;
				tile.transform.localScale = floorScale;
				//boxs[createCount] = tile;
				tile.transform.position = new Vector3(
					startPosition.x + tile.transform.localScale.x * i,
					0,
					startPosition.z + tile.transform.localScale.z * x);
				tile.transform.parent = stage.transform;
			//	tile.transform.name = "box" + createCount;
			//	createCount++;
			}
		}
		*/
	}
	
	
	// Update is called once per frame
	void Update () {
	//	dog.transform.Rotate(new Vector3(0,rotationSpeed,0));
	}

	void gameStart()
	{
		Application.LoadLevel("kinaTestScene");
	}



}
