using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {
	private Animator animator;
	public float v;
	public float h;
	private bool walk = false;
	private bool attack = false;
	private bool defend = false;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent ("Animator") as Animator;
	}
	
	// Update is called once per frame
	void Update () {

		v = Input.GetAxis ("JogadorVertical");
		h = Input.GetAxis ("Horizontal");

		Walking();
		Attacking();
		Defending();

	
	}

	void FixedUpdate(){

		animator.SetFloat ("Sprint", v);
		animator.SetBool ("Walk", walk);
		animator.SetBool ("Attack", attack);
		animator.SetBool ("Defend", defend);


	}


	void Attacking(){
		if (Input.GetKey (KeyCode.LeftControl)) {
			
			attack = true;
			
		} else {
			
			attack = false;
		}

	}

	void Defending(){
		if (Input.GetKey (KeyCode.LeftShift)) {
			
			defend = true;
			
		} else {
			
			defend = false;
		}

	}

	void Walking(){
		if (Input.GetKey (KeyCode.LeftAlt)) {

			walk = true;

		} else {
		
			walk = false;
		}
						
	}

}
