using UnityEngine;
using System.Collections;

public class MapTest : MonoBehaviour {

	public GameObject box;
	public GameObject[] boxs;
	public Material tile1,tile2;
	public int tileCount;
	public int createCount = 0;
	public Vector3 startPosition;
	string playerTag = "Player";
	public GameObject playerObj;
	public float moveTime;

	// Use this for initialization
	void Start () {
		GameObject stage = GameObject.Find("Stage");
		boxs = new GameObject[tileCount * tileCount];
		for (int i = 0; i < tileCount; i++) {
			for (int x = 0; x < tileCount; x++) {
				GameObject  tile = Instantiate(box,startPosition,Quaternion.identity) as GameObject;
				boxs[createCount] = tile;
				createCount++;
				tile.transform.position = new Vector3(
					startPosition.x + box.transform.localScale.x * i,
					0,
					startPosition.z + box.transform.localScale.z * x);
				tile.transform.parent = stage.transform;
				tile.transform.name = "box" + createCount;

			}
		}
		GameObject player = GameObject.FindWithTag(playerTag);
		playerObj = player;
		Vector3 boxPos = boxs[0].transform.position;
		//playerObj.transform.position = new Vector3(boxPos.x,1,boxPos.z); 
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray;
			RaycastHit hit;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit))
			{
				Vector3 newPos = new Vector3(hit.transform.position.x,1,hit.transform.position.z);
				iTween.MoveTo(playerObj,iTween.Hash("time",moveTime,"position",newPos,"easetype",iTween.EaseType.linear,"speed",5));
			}
		}
	}

	void endMove()
	{

	}

}
