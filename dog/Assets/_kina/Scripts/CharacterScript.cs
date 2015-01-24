using UnityEngine;
using System.Collections;

//[ExecuteInEditMode()]
public class CharacterScript : MonoBehaviour {
	public Vector3 targetPos;

	public Vector3 forward;
	public Vector3 back;
	public Vector3 right;
	public Vector3 left;
	public float moveTime;
	public Vector3[] vectols;
	public bool isMale;

	// Use this for initialization
	void Start () {
		vectols = new Vector3[4];
	}

	void Update () {
		Vector3 charaForward = transform.forward;
		Vector3 charaRight = transform.right;
		forward = transform.position + charaForward * 10;
		back = transform.position - charaForward * 10; 
		right = transform.position + charaRight * 10;
		left = transform.position - charaRight * 10;
		vectols[0] = forward;
		vectols[1] = back;
		vectols[2] = right;
		vectols[3] = left;
		//DrawLines.
		Debug.DrawLine(transform.position,vectols[0],Color.red);
		Debug.DrawLine(transform.position,vectols[1],Color.green);
		Debug.DrawLine(transform.position,vectols[2],Color.blue);
		Debug.DrawLine(transform.position,vectols[3],Color.cyan); 
		checkRay();
	}

	void checkRay()
	{    
		for (int i = 0; i < vectols.Length; i++) {
			Ray ray = new Ray(transform.position,vectols[i]);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit)) {
				if (isMale) {
					maleMove(hit.transform);
				} else {
					femaleMove(hit.transform);
				}
			}
		}
	}

	void maleMove(Transform hitObj)
	{
		if (hitObj.tag == Const.MALE_FOOD) {
			Vector3 targetPos = new Vector3(hitObj.position.x,1,hitObj.position.z);
			iTween.MoveTo(gameObject,iTween.Hash("position",targetPos,"speed",5,"easetype",iTween.EaseType.linear));
		} else if (hitObj.tag == Const.FEMALE_FOOD) {

		}
	}

	void femaleMove(Transform hitObj)
	{
		if (hitObj.tag == Const.FEMALE_FOOD) {

		} else if (hitObj.tag == Const.MALE_FOOD) {

		}
	}

	void characterMove(Vector3 pos)
	{
		iTween.MoveTo(gameObject,iTween.Hash("position",pos,"speed",5,"easetype",iTween.EaseType.linear));
	}
}
