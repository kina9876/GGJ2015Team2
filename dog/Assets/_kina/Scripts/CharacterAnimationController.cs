using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour {
	Animator animator;
	public AudioClip RunSE;
	public AudioClip voice_Like;
	public AudioClip voice_Hate;
	public AudioClip voice_Eat;
	public AudioSource audioSource;

	void Start(){
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

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
		audioSource.clip = RunSE;
		audioSource.PlayOneShot (RunSE);
	}

	public void escapeRun()
	{
		animator.SetBool ("SadWalking", true);
		audioSource.clip = RunSE;
		audioSource.PlayOneShot (RunSE);
	}

	public void eat()
	{
		animator.SetTrigger ("EatTrigger");
		audioSource.Stop ();
		audioSource.clip = voice_Eat;
		audioSource.Play ();
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
		audioSource.clip = voice_Hate;
		audioSource.Play ();
	}

}
