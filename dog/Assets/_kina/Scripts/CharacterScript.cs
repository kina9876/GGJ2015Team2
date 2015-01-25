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

	public CharacterAnimationController _animationController;


	// Use this for initialization
	void Start () {
		_animationController.idle();
		vectols = new Vector3[4];
	}

	void Update () {
		Vector3 charaForward = transform.forward;
		Vector3 charaRight = transform.right;
		Vector3 ModificationPos = new Vector3(transform.position.x,transform.position.y + 1,transform.position.z);
//		forward = ModificationPos + charaForward * 10;
//		back = ModificationPos - charaForward * 10; 
//		right = ModificationPos + charaRight * 10;
//		left = ModificationPos - charaRight * 10;
		forward = transform.forward;
		back = transform.forward * -1;
		right = transform.right;
		left = transform.right * -1;
		vectols[0] = forward;
		vectols[1] = back;
		vectols[2] = right;
		vectols[3] = left;
		//DrawLines.
//		Debug.DrawLine(transform.position,vectols[0],Color.red);
//		Debug.DrawLine(transform.position,vectols[1],Color.green);
//		Debug.DrawLine(transform.position,vectols[2],Color.blue);
//		Debug.DrawLine(transform.position,vectols[3],Color.cyan); 
		checkRay(); 
	}

	void checkRay()
	{    
		for (int i = 0; i < vectols.Length; i++) {
			Vector3 plusYPos = transform.position + new Vector3(0,1,0);
			Ray ray = new Ray(plusYPos,vectols[i]);
			RaycastHit hit;
			Debug.DrawLine(plusYPos,vectols[i]);
			if (Physics.Raycast(ray,out hit,Mathf.Infinity)) {
				Debug.Log("hit " + hit.transform.name);
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
		if (hitObj.tag == Const.FOOD_TAG) {
			if (hitObj.GetComponent<FoodScript>().isMalefood) {
				//MoveFood.
				Vector3 targetPos = new Vector3(hitObj.position.x,1,hitObj.position.z);
				//iTween.MoveTo(gameObject,iTween.Hash("position",targetPos,"speed",5,"easetype",iTween.EaseType.linear));
				iTween.LookTo(gameObject,iTween.Hash("looktarget",targetPos,"time",0.5f,"easetype",iTween.EaseType.linear,"oncomplete","characterMove","oncompleteparams",targetPos));
				//characterMove(targetPos);
			} else {
				// Escape.
				Vector3 escapeVec = checkEscapeVectol(targetPos);
				escapeVec = new Vector3(escapeVec.x,1,escapeVec.z);
				Debug.Log ("escapeVec" + escapeVec);
				iTween.LookTo(gameObject,iTween.Hash("looktarget",escapeVec,"time",0.5f,"oncomplete","characterEscape","oncompleteparams",escapeVec));
			}
		} 
	}

	void femaleMove(Transform hitObj)
	{
		if (hitObj.tag == Const.FOOD_TAG) {
			if (hitObj.GetComponent<FoodScript>().isMalefood) {
				//Escape.

			} else {
				//MoveFood.
				Vector3 targetPos = new Vector3(hitObj.position.x,1,hitObj.position.z);
				iTween.MoveTo(gameObject,iTween.Hash("position",targetPos,"speed",5,"easetype",iTween.EaseType.linear));
			}
		} 
	}

	void characterMove(Vector3 pos)
	{
		_animationController.run();
		iTween.MoveTo(gameObject,iTween.Hash("position",pos,"speed",5,"easetype",iTween.EaseType.linear));
	}

	void characterEscape(Vector3 pos)
	{
		_animationController.escapeRun();
		pos = pos;
		iTween.MoveTo(gameObject,iTween.Hash("position",-pos,"speed",5,"easetype",iTween.EaseType.linear));
	} 

	void OnTriggerEnter(Collider col) {
		if (col.tag == Const.WALL_TAG) {
			iTween.Stop();
		}
	}

	Vector3 checkEscapeVectol(Vector3 targetPos)
	{
		float x = Mathf.Abs(transform.position.x) - Mathf.Abs(targetPos.x);
		float z = Mathf.Abs(transform.position.z) - Mathf.Abs(targetPos.z);
		Vector3 escapeVec = Vector3.zero;
		if (x != 0) {
			//X.
			if (transform.position.x < targetPos.x) {
				//LeftEscape
				escapeVec = Vector3.left;
			} else {
				//RIghtEscape
				escapeVec = Vector2.right;
			}
		} else if (z != 0) {
			//Z.
			if (transform.position.z < targetPos.z) {
				//DownEsxape.
				escapeVec = Vector3.down;
			} else {
				//TopEscape.
				escapeVec = Vector3.forward;
			}
		}
		return escapeVec;
	}
}