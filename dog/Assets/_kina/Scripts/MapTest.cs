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
	public GameObject malePlayer;
	public GameObject femalePlayer;
	public float moveTime;
	public int[] walls;
	public GameObject maleFood,femaleFood;
	public GameObject[] houses;
	public GameObject insMaleFood;
	public GameObject insFemaleFood;
	public bool maleFlag;
	public int maleStart,femaleStart;

	// Use this for initialization
	void Start () {
		GameObject stage = GameObject.Find("Stage");
		boxs = new GameObject[tileCount * tileCount];

		houses = new GameObject[4];
		for (int i = 0; i < houses.Length;i++) {
			houses[i] = Resources.Load(Const.HOUSE_NAME + (i+1)) as GameObject;
		}

		for (int i = 0; i < tileCount; i++) {
			for (int x = 0; x < tileCount; x++) {
				GameObject  tile = Instantiate(box,startPosition,Quaternion.identity) as GameObject;
				boxs[createCount] = tile;
				tile.transform.position = new Vector3(
					startPosition.x + box.transform.localScale.x * i,
					0.5f,
					startPosition.z + box.transform.localScale.z * x);
				tile.transform.parent = stage.transform;
				tile.transform.name = "box" + createCount;
				createCount++;
			}
		}
		int surWallCount = (tileCount * (tileCount + 1)) + 4;
		Debug.Log("wall : " + surWallCount);
		for (int w = 0; w < tileCount; w++) {
			GameObject underWall = Instantiate(houses[Random.Range(0,houses.Length)]) as GameObject;
			GameObject topWall = Instantiate(houses[Random.Range(0,houses.Length)]) as GameObject;
			GameObject leftWall = Instantiate(houses[Random.Range(0,houses.Length)]) as GameObject;
			GameObject rightWall = Instantiate(houses[Random.Range(0,houses.Length)]) as GameObject;

			underWall.transform.position = boxs[0].transform.position + new Vector3(w,0.5f,-1);
			topWall.transform.position = boxs[tileCount -1].transform.position + new Vector3(w,0.5f,1);
			leftWall.transform.position = boxs[0].transform.position + new Vector3(-1,0.5f,w);
			rightWall.transform.position = boxs[boxs.Length - 1].transform.position + new Vector3 (1,0.5f,-w);

			underWall.transform.parent = stage.transform;
			topWall.transform.parent = stage.transform;
			leftWall.transform.parent = stage.transform;
			rightWall.transform.parent = stage.transform;

		}
//		GameObject player = GameObject.FindWithTag(playerTag);
//		malePlayer = player;
		Vector3 boxPos = boxs[maleStart].transform.position;
		malePlayer.transform.position = new Vector3(boxPos.x,1,boxPos.z); 
		Vector3 femalePos = boxs[femaleStart].transform.position;
		femalePlayer.transform.position = new Vector3(femalePos.x,1,femalePos.z);


		for (int w = 0; w < walls.Length; w++) {
			int num = Random.Range(0,houses.Length);
			GameObject wall = Instantiate(houses[Random.Range(0,houses.Length)]) as GameObject;
			Vector3 wallPos = boxs[walls[w]].transform.position;
			wallPos = new Vector3(wallPos.x,1,wallPos.z);
			wall.transform.position = wallPos;
		}
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
/*				malePlayer.GetComponent<CharacterScript>()*/

//				Vector3 newPos = new Vector3(hit.transform.position.x,2,hit.transform.position.z); 
//				if (maleFlag){
//					if (insMaleFood == null) {
//						insMaleFood = Instantiate(maleFood) as GameObject;
//					}
//					insMaleFood.transform.position = newPos;	
//				} else {
//					if (insFemaleFood == null) {
//						insFemaleFood = Instantiate(femaleFood) as GameObject;
//					}
//					insFemaleFood.transform.position = newPos;
//				}

			}
		}
	}

	void endMove()
	{

	}

}
