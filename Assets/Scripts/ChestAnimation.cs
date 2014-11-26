using UnityEngine;
using System.Collections;

public class ChestAnimation : MonoBehaviour {
	private Animator animator;
	private bool open;
	private bool abrindo;
	public ParticleSystem efeito;
	public Light spotLight;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent ("Animator") as Animator;
		open = false;
		abrindo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O)) {
			abrindo = true;
			ControleSom.tocarBauAbrindo();
			open = true;
			spotLight.gameObject.SetActive(true);
		} else {			
			open = false;
		}
		if (abrindo && !ControleSom.instance.audio.isPlaying) {
			efeito.Play();
			ControleSom.tocarBauEfeito();
			abrindo = false;
		}
	}


	void FixedUpdate(){
		

		animator.SetBool ("Open", open);
		
		
	}

}
