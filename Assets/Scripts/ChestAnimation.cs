using UnityEngine;
using System.Collections;

public class ChestAnimation : MonoBehaviour {
	private Animator animator;
	private bool open;
	public ParticleSystem efeito;
	public Light spotLight;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent ("Animator") as Animator;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O)) {
			
			open = true;
			efeito.Play();
			spotLight.gameObject.SetActive(true);
			
		} else {
			
			open = false;
		}
	}


	void FixedUpdate(){
		

		animator.SetBool ("Open", open);
		
		
	}

}
