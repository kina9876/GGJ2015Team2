using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour {
	Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
	}

	public void idle()
	{
		animator.SetBool ("isWalking", false);
	}

	public void run()
	{
		animator.SetBool ("isWalking", true);
	}

	public void escapeRun()
	{
		//animator.SetTrigger ("escapeRun");
	}

	public void eat()
	{
		animator.SetTrigger ("EatTrigger");
	}

	public void end()
	{
	//	animator.SetTrigger ();
	}

}
