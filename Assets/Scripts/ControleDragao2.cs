using UnityEngine;
using System.Collections;

public class ControleDragao2 : MonoBehaviour {

	public Animator animator;
	private bool andar, cauda, fogo, morte, voar;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Input.GetKey(KeyCode.UpArrow)){
			andar = true;
		}else{
			andar = false;
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			cauda = true;
		}else{
			cauda = false;
		}

		if(Input.GetKey(KeyCode.RightArrow)){
			morte = true;
		}else{
			morte = false;
		}

		if(Input.GetKey(KeyCode.DownArrow)){
			fogo = true;
		}else{
			fogo = false;
		}

		if(Input.GetKey(KeyCode.U)){
			voar = true;
		}else{
			voar = false;
		}

		animator.SetBool ("Andar", andar);
		animator.SetBool ("Cauda", cauda);
		animator.SetBool ("Fogo", fogo);
		animator.SetBool ("Morte", morte);
		animator.SetBool ("Voar", voar);


	}
}
