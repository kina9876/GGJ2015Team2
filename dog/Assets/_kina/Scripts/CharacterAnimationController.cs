using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour {
	Animator animator;
	//public AudioClip walkSE;
	public AudioClip voice_eat;


	void Awake(){
		animator = GetComponent<Animator> ();
	}

	public void idle()
	{
		animator.SetBool ("isWalking", false);
		animator.SetBool ("SadWalking", false);
	}

	public void run()
	{
		animator.SetBool ("isWalking", true);
	}

	public void escapeRun()
	{
		animator.SetBool ("SadWalking", true);
	}

	public void eat()
	{
		animator.SetTrigger ("EatTrigger");
	}

	public void end()
	{
		animator.SetTrigger ("Clear");
	}

	public void dead(){
		animator.SetTrigger ("Dead");
	}

	public void escapeSoundPlay()
	{

	}

}
